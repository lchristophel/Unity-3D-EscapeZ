using UnityEngine;
using UnityEngine.SceneManagement; // Namespace pour la gestion des scènes

public class GameOverScreen : MonoBehaviour
{
    // Fonction pour recommencer la partie
    public void RestartGame()
    {
        // Rechargez la scène actuelle
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        // Désactiver le curseur de la souris
        Cursor.visible = false;
    }

    // Fonction pour quitter la partie
    public void QuitGame()
    {
        // Retourner à l'écran d'accueil
        SceneManager.LoadScene(0);
    }

    // Fonction pour quitter l'application
    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}