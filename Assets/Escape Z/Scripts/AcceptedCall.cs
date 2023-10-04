using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptedCall : MonoBehaviour
{
    public AudioSource phoneAudioSource;
    
    public GameObject uiCall;
    public GameObject uiCalled;

    public void AcceptCall()
    {
        
        uiCall.SetActive(false);
        uiCalled.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }
}
