using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoButtonManager : MonoBehaviour
{
    [SerializeField] GameObject launcherObject;
    [SerializeField] GameObject processingBar;
    LauncherScript launch;
    bool connectFlag = false;
    void Start(){
        launch = launcherObject.GetComponent<LauncherScript>();
    }
    public void OnClickGoButton(){
        if(!connectFlag){
            launch.Connect();
            connectFlag = true;
            processingBar.SetActive(true);
        }
    }
}
