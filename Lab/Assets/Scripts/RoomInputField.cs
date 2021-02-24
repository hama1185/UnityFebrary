using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomInputField : MonoBehaviour
{
    public string roomname;
    [SerializeField] GameObject roomInput;
    TMP_InputField nameText;
    // Start is called before the first frame update
    void Start()
    {
        if(roomInput != null){
            nameText = roomInput.GetComponent<TMP_InputField>();
        }
    }

    public void SetRoomName(){
        roomname = nameText.text;
    }
}
