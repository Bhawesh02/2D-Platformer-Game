using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        AudioManager.Instance.PlaySfxMusic(SoundType.ButtonClick);

        levelSelect.SetActive(true);
    }

    private void ContinueLevel()
    {
        AudioManager.Instance.PlaySfxMusic(SoundType.ButtonClick);
        string sceneName = PlayerPrefs.GetString("Reached Level", Levels.levels[1]);


        SceneManager.LoadScene(sceneName);

        Debug.Log(sceneName);
    }
}
