using UnityEngine;
using System.Collections;

public class AmbientMusicController : MonoBehaviour
{
    public AudioClip[] musicClips;  // Tableau de clips audio
    private AudioSource audioSource;
    private int currentClipIndex = 0;

    public float delayBetweenClips = 2f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Assure-toi que tu as au moins un clip dans la liste
        if (musicClips.Length > 0)
        {
            PlayNextClip();
        }
    }

    // Fonction pour jouer le prochain clip
    void PlayNextClip()
    {
        audioSource.clip = musicClips[currentClipIndex];
        audioSource.Play();

        currentClipIndex++;
        if (currentClipIndex >= musicClips.Length)
            currentClipIndex = 0;

        // Lancer la coroutine pour le délai et passer au clip suivant
        StartCoroutine(PlayNextAfterDelay(audioSource.clip.length + delayBetweenClips));
    }

    // Coroutine pour le délai et le passage au clip suivant
    private IEnumerator PlayNextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayNextClip();
    }
}
