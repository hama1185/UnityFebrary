using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using Michsky.UI.ModernUIPack;
using Michsky;
using TMPro;

public class NameInputField : MonoBehaviourPunCallbacks
{
    static string playerNamePrefKey = "PlayerName";
    [SerializeField] GameObject nameInput;
    TMP_InputField nameText;

    void Start()
    {
        string defaultName = "";
        
        if(nameInput != null){
            nameText = nameInput.GetComponent<TMP_InputField>();
            if(PlayerPrefs.HasKey(playerNamePrefKey)){
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                nameText.text = defaultName;
            }
        }
    }

    public void SetPlayerName(){
        PhotonNetwork.NickName = nameText.text + " ";
        PlayerPrefs.SetString(playerNamePrefKey, nameText.text);
        Debug.Log(PhotonNetwork.NickName);
    }
}
