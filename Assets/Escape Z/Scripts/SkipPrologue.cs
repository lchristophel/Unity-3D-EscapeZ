using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipPrologue : MonoBehaviour
{
    public GameObject objectToBlink;  // Le GameObject à faire clignoter
    public float blinkInterval = 1.0f; // Intervalle de clignotement en secondes

    private bool isBlinking = true; // Indique si l'objet est en train de clignoter

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(2);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Démarrer la routine de clignotement
        StartCoroutine(BlinkCoroutine());
    }

    IEnumerator BlinkCoroutine()
    {
        while (true)
        {
            // Activer ou désactiver le GameObject
            objectToBlink.SetActive(isBlinking);

            // Inverser l'état du clignotement
            isBlinking = !isBlinking;

            // Attendre l'intervalle de clignotement
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
