using UnityEngine;
using System.Collections;

public class FadeManagerPrologue : MonoBehaviour 
{
    public string scene;
	public Color loadToColor = Color.black;
	
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // Charger la scène du jeu avec fondu lors de l'appuie sur échap
            Fade();
        }
    }

	public void Fade()
    {
        Initiate.Fade(scene, loadToColor, 1.0f);
    }
}
