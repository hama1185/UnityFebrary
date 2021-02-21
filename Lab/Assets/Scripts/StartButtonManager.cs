using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonManager : MonoBehaviour
{
    [SerializeField] GameObject launcherObject;
    LauncherScript launch;
    bool connectFlag = false;
    void Start(){
        launch = launcherObject.GetComponent<LauncherScript>();
    }
    public void onClickStartButton(){
        if(!connectFlag){
            launch.Connect();
            connectFlag = true;
        }
    }
}
