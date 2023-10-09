using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManagerEscapeZ : MonoBehaviour
{
    public Image fade; // Image utilisée pour le fondu
    public float fadeInDuration = 5.0f; // Durée du fondu entrant en secondes
    public float fadeOutDuration = 3.0f; // Durée du fondu sortant en secondes

    private bool isFading = false;  // Indique si le fondu est en cours

    void Start()
    {
        // Démarrer le fondu pour la première scène
        FadeIn();
    }

    // Fondu sortant
    public void FadeOut()
    {
        fade.CrossFadeAlpha(1.0f, fadeOutDuration, false);
        isFading = true;

        // Charger la nouvelle scène après le fondu sortant
        Invoke("LoadNextScene", fadeOutDuration);
    }

    // Fondu entrant
    public void FadeIn()
    {
        fade.CrossFadeAlpha(0.0f, fadeInDuration, false);
        isFading = true;

        // Réinitialiser le statut du fondu après le fondu entrant
        Invoke("ResetFadingStatus", fadeInDuration);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void ResetFadingStatus()
    {
        isFading = false;
    }
}