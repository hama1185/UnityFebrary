using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    
    Vector3 input;

    Rigidbody rb;
    public Vector3 acceleration;

    public Vector3 velocity;
    public float walkSpeed = 1.5f;
    float maxSpeed = 10f;
    bool isGrounded;
    

    void Start(){
        rb = this.GetComponent<Rigidbody>();

    }

    void FixedUpdate(){
        
        rb.AddForce(input * 10f,ForceMode.Acceleration);
        
    }

    void Update(){
        velocity = Vector3.zero;
        input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if(input.magnitude > 0f){
            //animation起動歩く
            this.transform.LookAt((transform.position + input));
            this.transform.Rotate(new Vector3(0f, -180f, 0f));
        }
        else{
            //停止中のアニメをいれる
        }
    }

}