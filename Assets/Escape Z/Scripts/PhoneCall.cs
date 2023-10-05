using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PhoneCall : MonoBehaviour
{
    public GameObject phone; // Référence au GO de l'image du téléphone
    public AudioSource phoneAudioSource; // Référence à l'audio source 
    public AudioClip Call; // Référence à l'audio clip
    
    void Start()
    {
        // Appeler la fonction après 8 secondes
        StartCoroutine(CallFunctionWithDelay(8f));
    }

    private IEnumerator CallFunctionWithDelay(float delay)
    {

        yield return new WaitForSeconds(delay);
        // Appele de la fonction ici
        PhoneCalling();
    }

    private void PhoneCalling()
    {
        // Active l'UI du téléphone
        phone.SetActive(true);
        // Jouer la sonnerie du téléphone
        phoneAudioSource.Play();
        // Jouer la conversation
        phoneAudioSource.PlayOneShot(Call);
        // Changement de scène
        SceneManager.LoadScene(2);
    }
}
