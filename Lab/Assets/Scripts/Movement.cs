using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UniRx;

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
    public float walkSpeed = 10f;
    public float rotateSpeed = 1.0f;
    float baseSpeed = 10f;
    float maxSpeed = 20f;
    bool isGrounded;
    

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
    }
    void ResetRigidbody(){
        rb.constraints = RigidbodyConstraints.None;
    }

    void ResetWalkSpeed(){
        walkSpeed = baseSpeed;
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Food"){
            rb.constraints = RigidbodyConstraints.FreezeAll;
            //3秒後に
            Destroy(collision.gameObject, 3f);
            Observable.Timer(TimeSpan.FromMilliseconds(3100)).Subscribe(_ => ResetRigidbody());
            //速度の変更
            walkSpeed = maxSpeed;
            Observable.Timer(TimeSpan.FromMinutes(1.5f)).Subscribe(_ => ResetWalkSpeed());
        }
    }
    void OnCollisionStay(Collision collision){
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
        if(collision.gameObject.name == "Wall(Clone)" 
        || (collision.gameObject.tag == "OtherPlayer"
        || collision.gameObject.tag == "Food")){
            rb.constraints = RigidbodyConstraints.None;
        }
    }

}
