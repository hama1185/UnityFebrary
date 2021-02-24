using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonManager : MonoBehaviour
{
    [SerializeField] GameObject Input;
    [SerializeField] GameObject Select;
    public void OnCliskStartButton(){
        Select.SetActive(true);
        Input.SetActive(false);
    }
}
