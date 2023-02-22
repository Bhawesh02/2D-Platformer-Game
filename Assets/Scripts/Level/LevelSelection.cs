using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Levels;

public class LevelSelection : MonoBehaviour
{
    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private Button selectLevelButton;
    [SerializeField]
    private GameObject levelSelect;

    private void Awake()
    {
        continueButton.onClick.AddListener(ContinueLevel);
        selectLevelButton.onClick.AddListener(SelectLevel);
    }

    private void SelectLevel()
    {
        levelSelect.SetActive(true);
    }

    private void ContinueLevel()
    {
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetString("Level", Levels.level1);
        }
        string sceneName = PlayerPrefs.GetString("Level");

        SceneManager.LoadScene(sceneName);

        Debug.Log(sceneName);
    }
}
