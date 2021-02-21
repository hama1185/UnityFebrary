using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class NameInputField : MonoBehaviourPunCallbacks
{
    static string playerNamePrefKey = "PlayerName";
    [SerializeField] InputField nameInput;
    void Start()
    {
        string defaultName = "";
        if(nameInput != null){
            if(PlayerPrefs.HasKey(playerNamePrefKey)){
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                nameInput.text = defaultName;
            }
        }
    }

    public void SetPlayerName(){
        PhotonNetwork.NickName = nameInput.text + " ";
        PlayerPrefs.SetString(playerNamePrefKey, nameInput.text);
        Debug.Log(PhotonNetwork.NickName);
    }
}
