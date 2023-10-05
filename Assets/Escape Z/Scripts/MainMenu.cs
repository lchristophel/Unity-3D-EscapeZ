using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   // Fonction pour lancer le jeu
    public void PlayGame()
    {
        // Charger la scène du jeu (à adapter avec le nom de la scène ou le numéro)
        SceneManager.LoadScene(1);
    }
}
