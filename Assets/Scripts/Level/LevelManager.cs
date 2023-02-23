using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }




    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if(GetLevelStatus(Levels.levels[1]) == LevelStatus.Locked)
            PlayerPrefs.SetInt(Levels.levels[1], (int)LevelStatus.Unlocked);
    }
    public static void SetLevelStatus(string level,LevelStatus status)
    {
        PlayerPrefs.SetInt(level,(int)status);
    }
    public static LevelStatus GetLevelStatus(string level)
    {
        LevelStatus status = (LevelStatus)PlayerPrefs.GetInt(level, (int)LevelStatus.Locked);
        return status;
    }
}
