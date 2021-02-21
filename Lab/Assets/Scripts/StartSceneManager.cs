using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneManager : MonoBehaviour
{
    bool enterflag = false;
    [SerializeField] GameObject Menu;

    void Update(){
        if(!enterflag){
            if(Input.GetKeyDown(KeyCode.Return)){
                Menu.SetActive(true);
                enterflag = true;
            }
        }
    }
}
