using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField]
    private GameObject levelComplete;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControler>() == null)
        {
            return;
        }
        string currentLevelName = SceneManager.GetActiveScene().name;
        levelComplete.SetActive(true);
        if (currentLevelName == Levels.lastLevel)
        {
            return;
        }
        int currentLevelIndex = Array.IndexOf(Levels.levels, currentLevelName);
        int nextLevelIndex = currentLevelIndex + 1;
        PlayerPrefs.SetInt(Levels.levels[nextLevelIndex], (int)LevelStatus.Unlocked);
        collision.gameObject.GetComponent<PlayerControler>().enabled = false;

    }
}
