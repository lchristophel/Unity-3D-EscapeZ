using UnityEngine;

public class FlashLightAudioController : MonoBehaviour
{
    public Light flashlight;  // Référence à la lumière de la lampe torche
    public AudioSource flashLightAudioSource; // Référence à l'audio source de la lampe torche
    public AudioClip switchOn; // Audio clip d'activation de lampe torche
    public AudioClip switchOff; // Audio clip de désactivation de la lampe torche

    void Update() // Vérifier constamment
    {
        // Si la touche primaire de la souris est enfoncée
        if (Input.GetMouseButtonDown(0))
        {
            // Inverser l'état de la lumière (activer si désactivée, et vice versa)
            bool isFlashlightActive = flashlight.gameObject.activeSelf;
            flashlight.gameObject.SetActive(!flashlight.gameObject.activeSelf);

            // Si la lampe toche est active
            if(isFlashlightActive)
            { // Jouer le son de de désactivation
                flashLightAudioSource.PlayOneShot(switchOff);
            }
            else
            { // Jouer le son d'activation
                flashLightAudioSource.PlayOneShot(switchOn);
            }
        }
    }
}