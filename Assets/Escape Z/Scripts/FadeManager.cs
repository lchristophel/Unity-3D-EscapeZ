using UnityEngine;
using System.Collections;

public class FadeManager : MonoBehaviour 
{
    public string scene;
	public Color loadToColor = Color.black;
	
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            // Charger la scène du jeu avec fondu lors de l'appuie sur entrée
            Fade();
        }
    }

	public void Fade()
    {
        Initiate.Fade(scene, loadToColor, 1.0f);
    }
}
