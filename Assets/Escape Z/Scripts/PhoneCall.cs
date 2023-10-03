using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCall : MonoBehaviour
{
    public GameObject phone;
    public AudioSource phoneAudioSource;
    
    IEnumerator Start()
    {
        Debug.Log("lancement");
        // Attendre 3 secondes
        yield return new WaitForSeconds(3f);
        Debug.Log("3 secondes");

        phone.SetActive(true);
        Debug.Log("1 instruction");
        phoneAudioSource.Play();
        Debug.Log("2 instruction");
    }
}
