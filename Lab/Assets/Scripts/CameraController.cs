﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public GameObject frontCamera;
    public GameObject backCamera;
    public GameObject upCamera;

    public void setCamera(){
        Player = GameObject.FindWithTag("Player");
        frontCamera = Player.transform.GetChild(2).gameObject;
        backCamera = Player.transform.GetChild(3).gameObject;

        backCamera.SetActive(true);
        frontCamera.SetActive(false);
        upCamera.SetActive(false);
    }

    public void changeCamera(){
        if(backCamera.activeSelf){
            frontCamera.SetActive(true);
            backCamera.SetActive(false);
        }
        else if(frontCamera.activeSelf){
            upCamera.SetActive(true);
            frontCamera.SetActive(false);
        }
        else{
            backCamera.SetActive(true);
            upCamera.SetActive(false);
        }
    }
}
