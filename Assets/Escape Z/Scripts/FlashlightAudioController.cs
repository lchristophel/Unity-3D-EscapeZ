using UnityEngine;

public class FlashLightAudioController : MonoBehaviour
{
    public Light flashlight;  // Référence à la lumière de la lampe torche
    public AudioSource flashLightAudioSource;
    public AudioClip switchOn;
    public AudioClip switchOff;

    void Update()
    {
        // Vérifier si la touche primaire de la souris est enfoncée
        if (Input.GetMouseButtonDown(0))
        {
            // Inverser l'état de la lumière (activer si désactivée, et vice versa)
            bool isFlashlightActive = flashlight.gameObject.activeSelf;
            flashlight.gameObject.SetActive(!flashlight.gameObject.activeSelf);
            if(isFlashlightActive)
            { // Si l'audioSource de la lampe torche n'est pas en train de jouer un son
                flashLightAudioSource.PlayOneShot(switchOff); // Jouer le son off de la flashlight
            }
            else
            {
                flashLightAudioSource.PlayOneShot(switchOn); // Jouer le son off de la flashlight
            }
        }
    }
}
