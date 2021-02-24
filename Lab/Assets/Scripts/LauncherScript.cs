using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class LauncherScript : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject SceneManager;
    RoomInputField roomInputField;

    void Start(){
        roomInputField = SceneManager.GetComponent<RoomInputField>();
    }
    //スタート時に呼び出される
    public void Connect(){
        if(!PhotonNetwork.IsConnected){
            PhotonNetwork.ConnectUsingSettings();//接続
            Debug.Log("接続しました");
        }
    }

    //コールバック
    public override void OnConnectedToMaster(){
        Debug.Log("OnConnectedToMasterが呼ばれました");
        // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
        if(roomInputField.roomname == ""){
            PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
        }
        else{
            PhotonNetwork.JoinOrCreateRoom(roomInputField.roomname, new RoomOptions(), TypedLobby.Default);
        }
    }

    public override void OnJoinedRoom(){
        Debug.Log("入室しました");
        PhotonNetwork.LoadLevel("Race");
    }

}
