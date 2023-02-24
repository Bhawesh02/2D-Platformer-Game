using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelComplete : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI title;
    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private Button lobbyButton;

    private string currentLevelName;

    private void Awake()
    {
        continueButton.onClick.AddListener(NextLevel);
        restartButton.onClick.AddListener(RestartLevel);
        lobbyButton.onClick.AddListener(GoLobby);
        currentLevelName = SceneManager.GetActiveScene().name;
        if(currentLevelName == Levels.lastLevel)
        {
            title.text += "\nGame Cleared";
            continueButton.gameObject.SetActive(false);
        }
    }

    private void GoLobby()
    {
        Debug.Log("Going Lobby");
        SceneManager.LoadScene(Levels.GetSceneName(0));
    }

    private void RestartLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void NextLevel()
    {
        int currentLevelIndex = Array.IndexOf(Levels.levels, currentLevelName);
        int nextLevelIndex = currentLevelIndex + 1;
        if (nextLevelIndex < Levels.levels.Length)
        {
            PlayerPrefs.SetString("Reached Level", Levels.levels[nextLevelIndex]);
            PlayerPrefs.SetInt(currentLevelName, (int)LevelStatus.Completed);
            SceneManager.LoadScene(Levels.GetSceneName(nextLevelIndex));
        }

    }
}
