using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Photon.Pun;
using Photon.Realtime;

public class NameSet : MonoBehaviourPunCallbacks, IPunObservable
{
    public static GameObject localPlayer; 
    void Awake(){
        if(photonView.IsMine){
            NameSet.localPlayer = this.gameObject;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        var Text = this.transform.GetChild(4).GetComponent<TMP_Text>();
        if(!photonView.IsMine){
            return;
        }
        Text.text = photonView.Owner.NickName;
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) 
    {
        
    }
}
