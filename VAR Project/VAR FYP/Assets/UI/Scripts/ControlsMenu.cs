using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject menu2;
    
    public void ShowControls()
    {
        menu.SetActive(true);
        menu2.SetActive(false);
    }

    public void HideControls()
    {
        menu.SetActive(false);
        menu2.SetActive(true);
    }
}
