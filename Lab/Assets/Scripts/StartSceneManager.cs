using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneManager : MonoBehaviour
{
    bool enterflag = false;
    [SerializeField] GameObject launcherObject;
    LauncherScript launch;

    void Start(){
        launch = launcherObject.GetComponent<LauncherScript>();
    }
    void Update(){
        if(!enterflag){
            if(Input.GetKeyDown(KeyCode.Return)){
                //launch.Connect();
                enterflag = true;
            }
        }
    }
}
