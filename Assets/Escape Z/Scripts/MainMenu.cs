using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Charger la scène du jeu (à adapter avec le nom de votre scène de jeu)
        SceneManager.LoadScene(1);
    }
}

