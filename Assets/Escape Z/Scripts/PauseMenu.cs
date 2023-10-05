using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // L'UI du menu pause
    public Rigidbody playerRigidbody; // Rb du joueur
    public FirstPersonLook firstPersonLook; // Script de vision FPS
    public GameObject deathScreen; // GO du DeathScreen
    
    private bool isPaused = false; // Variable bool de la pause

    void Update() // Vérifier constamment
    {
        // Attribuer l'état du deathscreen
        bool activeDeathScreen = deathScreen.activeSelf;

        // Si l'état du deathscreen est actif
        if(activeDeathScreen)
        {
            // Ne pas executer cette fonction
            return;
        }
        // Sinon si échap est pressée
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) // Mais si l'écran est déjà sur pause
                Resume(); // Executer la fonction pour retirer la pause
            else // Sinon exécuter la fonction Pause();
                Pause();
        }
    }

    public void Pause()
    {
        // Activer le menu UI pause
        pauseMenuUI.SetActive(true);
        playerRigidbody.isKinematic = true; // Geler le rb du joueur
        Time.timeScale = 0f; // Arrêter le temps du jeu
        // Si le rigidbody du joueur existe et que le script de vision FPS aussi 
        if(playerRigidbody != null && firstPersonLook != null) 
        {   
            firstPersonLook.enabled = false; // Désactiver la vision FPS
        }
        Cursor.visible = true; // Faire apparaître le curseur de la souris
        Cursor.lockState = CursorLockMode.Confined;
        isPaused = true; // Définir la variable isPaused sur true
    }

    public void Resume()
    {
        // Désactiver le menu UI pause
        pauseMenuUI.SetActive(false);
        playerRigidbody.isKinematic = false; // Dégeler le rb du joueur
        Time.timeScale = 1f; // Revenir au temps normal
        // Si le rigidbody du joueur existe et que le script de vision FPS aussi 
        if(playerRigidbody != null && firstPersonLook != null) 
        {   
            firstPersonLook.enabled = true; // Activer la vision FPS
        }
        Cursor.visible = false; // Faire dispaître le curseur de la souris
        Cursor.lockState = CursorLockMode.None;
        isPaused = false; // Définir la variable isPaused sur false
    }
}
