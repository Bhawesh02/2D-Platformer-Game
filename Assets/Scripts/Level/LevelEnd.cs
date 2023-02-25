using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Levels;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField]
    private string nextLevelName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControler>() == null)
        {
            return;
        }
        if(PlayerPrefs.GetString("Level") == Levels.lastLevel)
        {
            Debug.Log("Game cvleared!!");
            PlayerPrefs.SetString("Level", Levels.level1);
            return;
        }
        string levelName = Levels.GetSceneName(nextLevelName);
        PlayerPrefs.SetString("Level",levelName);
        SceneManager.LoadScene(levelName);
    }
}
