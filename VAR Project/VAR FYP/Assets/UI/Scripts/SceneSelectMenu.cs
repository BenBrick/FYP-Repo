using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSelectMenu : MonoBehaviour
{

    public GameObject startCanvas;
    public GameObject scenarioCanvas;
    
    public void HideCanvas()
    {
        startCanvas.SetActive(false);
        scenarioCanvas.SetActive(true);
    }

    public void BackMenu()
    {
        startCanvas.SetActive(true);
        scenarioCanvas.SetActive(false);
    }
    
}
