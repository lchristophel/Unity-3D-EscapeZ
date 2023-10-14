using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionText : MonoBehaviour
{
    public GameObject missionText;
    public GameObject areaText;
    // Start is called before the first frame update
    void Start()
    {
        missionText.SetActive(true);
        areaText.SetActive(true);
        StartCoroutine(SetToFalseMissionText(5f));
    }

    IEnumerator SetToFalseMissionText(float delay)
    {
        // Attendre l'intervalle de clignotement
        yield return new WaitForSeconds(delay);
        missionText.SetActive(false);
        areaText.SetActive(false);
    }
}
