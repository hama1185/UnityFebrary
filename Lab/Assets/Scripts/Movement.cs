using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UniRx;
using UniRx.Triggers;

public class Movement : MonoBehaviour
{
    //オンライン化に必要な部分
    public PhotonView myPV;
    public PhotonTransformView myPTV;

    [SerializeField]
    Animator animator;
    
    Vector3 input;
    float ahead;
    float rotation;

    Rigidbody rb;
    public Vector3 acceleration;

    public Vector3 velocity;
    public float walkSpeed = 15f;
    public float rotateSpeed = 1.0f;
    float baseSpeed = 15f;
    float maxSpeed = 20f;
    bool isGrounded;
    bool carrotFlag = false;
    

    void Start(){
        if(!myPV.IsMine){
            return;
        }
        rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        if(!myPV.IsMine){
            return;
        }
        Vector3 newPositon;
        newPositon.x = transform.position.x + velocity.x * Time.fixedDeltaTime;
        newPositon.y = transform.position.y;
        newPositon.z = transform.position.z + velocity.z * Time.fixedDeltaTime;
        rb.MovePosition(newPositon);
    }

    void Update(){
        if(!myPV.IsMine){
            return;
        }

        velocity = Vector3.zero;
        ahead = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");
        input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if(input.magnitude > 0f){
            //animation起動歩く
            animator.SetBool("isWalking", true);
            this.transform.Rotate(new Vector3(0f, rotation * rotateSpeed, 0f));
            Vector3 objectfoward = Quaternion.Euler(0f, 180f, 0f) * transform.forward;

            velocity = ahead * objectfoward * walkSpeed;//+がついてるのは謎
        }
        else{
            //停止中のアニメをいれる
            animator.SetBool("isWalking", false);
        }

        //ニンジンの生成
        if(Input.GetKeyUp(KeyCode.Space)){
            Vector3 targetPositon;
            targetPositon.x = transform.position.x;
            targetPositon.y = transform.position.y + 10f;
            targetPositon.z = transform.position.z;
            if(!carrotFlag){
                PhotonNetwork.Instantiate("carrotRigit", targetPositon, Quaternion.identity, 0);
                carrotFlag = true;
            }
        }
    }
    void ResetRigidbody(){
        rb.constraints = RigidbodyConstraints.None;
    }

    void ResetWalkSpeed(){
        walkSpeed = baseSpeed;
        //生成できるようにした
        carrotFlag = false;
    }

    void OnCollisionEnter(Collision collision){
        if(!myPV.IsMine){
            return;
        }
        if(collision.gameObject.tag == "Food"){
            rb.constraints = RigidbodyConstraints.FreezeAll;
            // Observable.Timer(TimeSpan.FromMilliseconds(1000)).Subscribe(_ => 
            // PhotonNetwork.Destroy(collision.gameObject));
            Observable.Timer(TimeSpan.FromMilliseconds(3100)).Subscribe(_ => ResetRigidbody());
            //速度の変更
            walkSpeed = maxSpeed;
            Observable.Timer(TimeSpan.FromMinutes(1.0f)).Subscribe(_ => ResetWalkSpeed());
        }
    }
    void OnCollisionStay(Collision collision){
        if(!myPV.IsMine){
            return;
        }
        if(collision.gameObject.name == "Wall(Clone)" 
        || collision.gameObject.tag == "OtherPlayer"){
            rb.constraints = RigidbodyConstraints.FreezePositionY
            | RigidbodyConstraints.FreezeRotationX
            | RigidbodyConstraints.FreezeRotationZ;
        }
        if(collision.gameObject.tag == "Food"){
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    void OnCollisionExit(Collision collision){
        if(!myPV.IsMine){
            return;
        }
        if(collision.gameObject.name == "Wall(Clone)" 
        || collision.gameObject.tag == "OtherPlayer"){
            rb.constraints = RigidbodyConstraints.None;
        }
    }

}
