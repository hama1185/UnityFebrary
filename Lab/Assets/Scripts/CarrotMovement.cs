using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UniRx;
using UniRx.Triggers;

public class CarrotMovement : MonoBehaviour
{
    public PhotonView myPV;
    public PhotonTransformView myPTV;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        if(!myPV.IsMine){
            return;
        }
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "OtherPlayer"){
            try{
                Observable.Timer(TimeSpan.FromMilliseconds(500)).Subscribe(_ => PhotonNetwork.Destroy(this.gameObject));
            }catch(MissingReferenceException){}
        }
    }
}
