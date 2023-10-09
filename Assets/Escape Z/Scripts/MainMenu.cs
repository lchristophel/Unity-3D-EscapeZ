using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Return))
        {
            // Charger la scène du jeu (à adapter avec le nom de la scène ou le numéro)
            SceneManager.LoadScene(1);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // Fonction pour quitter l'application
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}
