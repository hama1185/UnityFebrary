using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class LauncherScript : MonoBehaviourPunCallbacks
{
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
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    }

    public override void OnJoinedRoom(){
        Debug.Log("入室しました");
        SceneManager.LoadScene("Race");
    }

}
