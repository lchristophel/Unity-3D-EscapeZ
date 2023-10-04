using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptedCall : MonoBehaviour
{
    public AudioSource phoneAudioSource;
    public AudioClip Call;
    public GameObject uiCall;
    public GameObject uiCalled;
    public Rigidbody playerRigidbody; // Rb du joueur
    public FirstPersonLook firstPersonLook; // Script de vision FPS

    public void AcceptCall()
    {
        phoneAudioSource.PlayOneShot(Call);
        uiCall.SetActive(false);
        uiCalled.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        if(playerRigidbody != null && firstPersonLook != null) // Si le rigidbody du joueur existe et que le script de vision FPS aussi 
        {   
            firstPersonLook.enabled = false; // Désactiver la possibilité de bouger la vue (FPS)
        }
    }
}
