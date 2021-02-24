using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartSceneManager : MonoBehaviour
{
    bool enterflag = false;
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject Under;

    void Update(){
        if(!enterflag){
            if(Input.GetKeyDown(KeyCode.Return)){
                Under.SetActive(false);
                Menu.SetActive(true);
                enterflag = true;
            }
        }
    }
}
