using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class ConnectGameManager : MonoBehaviourPunCallbacks
{
    CameraController cameraController;
    public GameObject playerPrefab;//あとでここを変更
    void Start(){
        if(!PhotonNetwork.IsConnected){
            SceneManager.LoadScene("Launcher");
            return;
        }
        //カメラスクリプトを取得
        cameraController = this.GetComponent<CameraController>();
        //自分のプレイヤーを生成
        GameObject player = PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f, 1f, 0f), Quaternion.identity, 0);
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
