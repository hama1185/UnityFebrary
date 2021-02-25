using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class ConnectGameManager : MonoBehaviourPunCallbacks
{
    CameraController cameraController;
    //public GameObject playerPrefab;//あとでここを変更
    string createName;
    
    void Start(){
        if(!PhotonNetwork.IsConnected){
            SceneManager.LoadScene("Launcher");
            return;
        }
        //カメラスクリプトを取得
        cameraController = this.GetComponent<CameraController>();
        //自分のプレイヤーを生成
        if(SelectViewScript.selectCharactor == "random"){
            if(Random.value >= 0.5f){
                createName = "poteto";
            }
            else{
                createName = "siromo";
            }
        }
        else{
            createName = SelectViewScript.selectCharactor;
        }
        GameObject player = PhotonNetwork.Instantiate(createName, new Vector3(0f, 1f, 0f), Quaternion.identity, 0);
        player.tag = "Player";

        Movement movement = player.GetComponent<Movement>();
        movement.enabled = true;

        cameraController.setCamera();
    }
    
    void OnGUI(){
        //ログインの状態を出力
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }
}
