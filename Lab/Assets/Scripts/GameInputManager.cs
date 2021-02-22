using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputManager : MonoBehaviour
{
    CameraController cameraController;
    // Start is called before the first frame update
    void Start(){
        cameraController = this.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift)){
            cameraController.changeCamera();
        }
    }
}
