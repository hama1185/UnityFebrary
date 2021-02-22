using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Movement : MonoBehaviour
{
    //オンライン化に必要な部分
    public PhotonView myPV;
    public PhotonTransformView myPTV;

    [SerializeField]
    Animator animator;
    
    Vector3 input;

    Rigidbody rb;
    public Vector3 acceleration;

    public Vector3 velocity;
    public float walkSpeed = 15f;
    float maxSpeed = 30f;
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
        newPositon.x = transform.position.x - velocity.x * Time.fixedDeltaTime;
        newPositon.y = transform.position.y;
        newPositon.z = transform.position.z - velocity.z * Time.fixedDeltaTime;
        rb.MovePosition(newPositon);
    }

    void Update(){
        if(!myPV.IsMine){
            return;
        }

        velocity = Vector3.zero;
        input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if(input.magnitude > 0f){
            //animation起動歩く
            animator.SetBool("isWalking", true);
            this.transform.LookAt((transform.position + input));
            this.transform.Rotate(new Vector3(0f, -180f, 0f));
            Vector3 objectfoward = transform.forward;
            objectfoward.y += -180f; 
            velocity += objectfoward * walkSpeed;//+がついてるのは謎
        }
        else{
            //停止中のアニメをいれる
            animator.SetBool("isWalking", false);
        }
    }
    //接触判定も入れる


}
