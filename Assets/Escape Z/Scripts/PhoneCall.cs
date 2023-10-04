using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PhoneCall : MonoBehaviour
{
    public GameObject phone;
    public AudioSource phoneAudioSource;
    public AudioClip Call;
    
    void Start()
    {
        // Appeler la fonction après 3 secondes
        StartCoroutine(CallFunctionWithDelay(8f)); // 3 secondes
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
        phoneAudioSource.PlayOneShot(Call);
        SceneManager.LoadScene(2);
    }
}
