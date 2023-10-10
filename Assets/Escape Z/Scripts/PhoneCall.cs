using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PhoneCall : MonoBehaviour
{
    public GameObject phoneRingingUI; // Référence au GO de l'image du téléphone qui sonne
    public GameObject phoneConversationUI; // Référence au GO de l'image du téléphone en conversation
    public AudioSource phoneAudioSource; // Référence à l'audio source 
    public AudioClip conversationAudioClip; // Référence à l'audio clip
    public AudioClip ringingAudioClip;
    public AudioClip endPhoneAudioClip;
    public string scene;
	public Color loadToColor = Color.black;
    
    void Start()
    {
        // Appeler la fonction après 8 secondes
        StartCoroutine(CallPhoneRingingWithDelay(5f));
    }

    // La fonction de la couroutine dans laquelle va s'insérer le délai précédemment donné
    private IEnumerator CallPhoneRingingWithDelay(float delay)
    {   // Fait patienter le délai
        yield return new WaitForSeconds(delay);
        // Appele de la fonction ici
        PhoneRinging();
    }

    private IEnumerator CallPhoneConversationWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PhoneConversation();
    }

    private void PhoneRinging()
    {
        // Active l'UI du téléphone
        phoneRingingUI.SetActive(true);
        // Jouer la sonnerie du téléphone
        phoneAudioSource.PlayOneShot(ringingAudioClip);
        StartCoroutine(CallPhoneConversationWithDelay(6f));
    }

    private void PhoneConversation()
    {
        phoneRingingUI.SetActive(false);
        phoneConversationUI.SetActive(true);
        // Jouer la conversation
        phoneAudioSource.PlayOneShot(conversationAudioClip);
        StartCoroutine(CallLoadScene2WithDelay(27f));
    }

    private IEnumerator CallLoadScene2WithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Son de fin d'appel
        phoneAudioSource.PlayOneShot(endPhoneAudioClip);
        phoneConversationUI.SetActive(false);
        // Changement de scène
        Fade();
    }

    public void Fade()
    {
        Initiate.Fade(scene, loadToColor, 1.0f);
    }
}
