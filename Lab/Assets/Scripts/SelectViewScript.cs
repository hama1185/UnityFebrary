using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectViewScript : MonoBehaviour
{
    [SerializeField] GameObject potetoImage;
    [SerializeField] GameObject siromoImage;
    [SerializeField] GameObject questionImage;
    // Start is called before the first frame update
    public static string selectCharactor = "random";

    public void OnChangedValuePoteto(){
        potetoImage.SetActive(true);
        siromoImage.SetActive(false);
        questionImage.SetActive(false);
        selectCharactor = "poteto";
    }

    public void OnChangedValueSiromo(){
        potetoImage.SetActive(false);
        siromoImage.SetActive(true);
        questionImage.SetActive(false);
        selectCharactor = "siromo";
    }

    public void OnChangedValueRandom(){
        potetoImage.SetActive(false);
        siromoImage.SetActive(false);
        questionImage.SetActive(true);
        selectCharactor = "random";
    }
}
