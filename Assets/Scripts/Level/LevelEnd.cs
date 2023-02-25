using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField]
    private int nextLevelNum;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControler>() == null)
        {
            return;
        }
        string curLevelName = SceneManager.GetActiveScene().name;
        if (curLevelName == Levels.lastLevel)
        {
            Debug.Log("Game cvleared!!");
            return;
        }
        string nextLevelName = Levels.GetSceneName(nextLevelNum);
        PlayerPrefs.SetString("Reached Level", nextLevelName);
        PlayerPrefs.SetInt(curLevelName, (int)LevelStatus.Completed);
        PlayerPrefs.SetInt(nextLevelName, (int)LevelStatus.Unlocked);
        SceneManager.LoadScene(nextLevelName);
    }
}
