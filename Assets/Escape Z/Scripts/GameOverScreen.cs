using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
