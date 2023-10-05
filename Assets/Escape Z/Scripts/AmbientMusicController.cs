using UnityEngine;
using System.Collections;

public class AmbientMusicController : MonoBehaviour
{
    public AudioClip[] musicClips;  // Tableau de clips audio
    public float delayBetweenClips = 2f; // Délai entre chacun d'entre eux

    private AudioSource audioSource; // Récupération de l'audio source du GO
    private int currentClipIndex = 0; // Index du clip en cours dans le tableau de clips

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Récupération de l'audio source du GO
        // Si l'index du tableau de clips est inférieur à zéro 
        if (musicClips.Length > 0)
        { // Lancer la fonction PlayNextClip
            PlayNextClip();
        }
    }

    // Fonction pour jouer le prochain clip
    void PlayNextClip()
    {
        // Attribuer l'index en cours du tableau des clips au clip de l'audio source
        audioSource.clip = musicClips[currentClipIndex];
        // Lancer le clip
        audioSource.Play();
        // Incrémenter l'index du clip en cours
        currentClipIndex++;
        // Si l'index du clip en cours est supérieur ou égal à la taille du tableau des clips
        if (currentClipIndex >= musicClips.Length)
            // Revenir à zéro
            currentClipIndex = 0;

        // Lancer la coroutine pour le délai entre les clips avant le passage au clip suivant
        StartCoroutine(PlayNextAfterDelay(audioSource.clip.length + delayBetweenClips));
    }

    // Coroutine pour le délai et le passage au clip suivant
    private IEnumerator PlayNextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayNextClip();
    }
}