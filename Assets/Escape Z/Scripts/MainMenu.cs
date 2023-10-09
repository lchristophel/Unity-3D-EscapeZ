using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    void Update()
    {
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
