using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Levels;

[RequireComponent(typeof(Button))]
public class SceneLoader : MonoBehaviour
{
    
    private Button button;

    [SerializeField]
    private string sceneName;

    private void Awake()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        sceneName = Levels.GetSceneName(sceneName);
        if(sceneName != Levels.GetSceneName("Lobby"))
        {
            PlayerPrefs.SetString("Level", sceneName);
        }
        SceneManager.LoadScene(sceneName);
    }
}
