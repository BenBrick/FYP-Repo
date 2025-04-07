using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenario3Loader : MonoBehaviour
{

    [SerializeField] Slider slider;
    [SerializeField] GameObject canvas;
    
    public void LoadScene()
    {
        canvas.SetActive(true);
        this.gameObject.SetActive(false);
        AsyncOperation async = SceneManager.LoadSceneAsync(3);
        while (!async.isDone)
        {
            slider.value = async.progress;
        }
    }
    
}