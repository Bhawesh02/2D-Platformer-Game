using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SceneLoader : MonoBehaviour
{
    
    private Button button;

    [SerializeField]
    private int levelNum;

    private void Awake()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(LoadScene);
    }

    public  void LoadScene()
    {
        string sceneName = Levels.GetSceneName(levelNum);
        if (levelNum == 0)
        {
            SceneManager.LoadScene(sceneName);
            return;
        }
        if(LevelManager.GetLevelStatus(sceneName) == LevelStatus.Locked)
        {
            Debug.Log("Level: "+sceneName+" is locked");
            return;
        }
        PlayerPrefs.SetString("Reached Level", sceneName);
        SceneManager.LoadScene(sceneName);

    }
}
