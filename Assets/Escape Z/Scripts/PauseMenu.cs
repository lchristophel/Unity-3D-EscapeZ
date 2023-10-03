using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // L'UI du menu pause
    public Rigidbody playerRigidbody; // Rb du joueur
    public FirstPersonLook firstPersonLook; // Script de vision FPS
    public GameObject deathScreen; // GO du DeathScreen
    
    private bool isPaused = false; // Bool de la pause

    void Update()
    {
        bool activeDeathScreen = deathScreen.activeSelf;

        if(activeDeathScreen)
        {
        return;
        }

        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Si Échap est pressée, basculez entre pause et reprise du jeu
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        // Afficher le menu pause
        pauseMenuUI.SetActive(true);
        playerRigidbody.isKinematic = true; // Geler le rb du joueur
        Time.timeScale = 0f; // Arrêter le temps du jeu
        if(playerRigidbody != null && firstPersonLook != null) // Si le rigidbody du joueur existe et que le script de vision FPS aussi 
        {   
            firstPersonLook.enabled = false; // Désactiver la vision FPS
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        isPaused = true;
    }

    public void Resume()
    {
        // Cacher le menu pause
        pauseMenuUI.SetActive(false);
        playerRigidbody.isKinematic = false; // Dégeler le rb du joueur
        Time.timeScale = 1f; // Revenir au temps normal
        if(playerRigidbody != null && firstPersonLook != null) // Si le rigidbody du joueur existe et que le script de vision FPS aussi 
        {   
            firstPersonLook.enabled = true; // Activer la vision FPS
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        isPaused = false;
    }
}
