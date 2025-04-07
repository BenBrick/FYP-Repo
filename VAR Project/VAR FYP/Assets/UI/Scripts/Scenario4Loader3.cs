using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenario4Loader : MonoBehaviour
{

    [SerializeField] Slider slider;
    [SerializeField] GameObject canvas;
    
    public void LoadScene()
    {
        canvas.SetActive(true);
        this.gameObject.SetActive(false);
        AsyncOperation async = SceneManager.LoadSceneAsync(4);
        while (!async.isDone)
        {
            slider.value = async.progress;
        }
    }
    
}