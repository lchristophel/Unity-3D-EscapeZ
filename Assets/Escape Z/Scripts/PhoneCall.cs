using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCall : MonoBehaviour
{
    public GameObject phone;
    public AudioSource phoneAudioSource;
    
    void Start()
    {
        // Appeler la fonction après 3 secondes
        StartCoroutine(CallFunctionWithDelay(3f));  // 3 secondes
    }

    private IEnumerator CallFunctionWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Appeler ta fonction ici
        PhoneCalling();
    }

    private void PhoneCalling()
    {
            phone.SetActive(true);
            phoneAudioSource.Play();
    }
}
