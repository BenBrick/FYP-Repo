using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Scenario1Loader : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] GameObject loadingScreen;
    [SerializeField] GameObject sceneLoader;
    
    public void LoadScene()
    {
        loadingScreen.SetActive(true);
        sceneLoader.SetActive(false);
        AsyncOperation async = SceneManager.LoadSceneAsync(1);
        slider.value = async.progress;
    }
    
}
