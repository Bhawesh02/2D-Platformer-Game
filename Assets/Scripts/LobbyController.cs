using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button buttonPlay;
    public Button quitPlay;
    [SerializeField]
    private GameObject continueSelection;
    private void Awake()
    {
        buttonPlay.onClick.AddListener(SelectLevel);
        quitPlay.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    private void SelectLevel()
    {
        continueSelection.SetActive(true);
    }
}
