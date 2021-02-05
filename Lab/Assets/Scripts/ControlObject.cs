using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObject : MLAPI.NetworkedBehaviour
{
    private Rigidbody rb;
    private float speed = 10.0f;
    void Start() {
        rb = this.GetComponent<Rigidbody>();
    }
    void FixedUpdate() {
        if(this.IsOwner) {
            float h = Input.GetAxis("Horizontal") * speed;
            float v = Input.GetAxis("Vertical") * speed;

            rb.AddForce(h, 0, v);
        }
    }
}
