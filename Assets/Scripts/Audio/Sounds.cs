using System;
using UnityEngine;

public enum SoundType
{
    BakgroundMusic,
    ButtonClick,
    PlayerMovement,
    PlayerDeath,
    EnemyDeath

}
[Serializable]
public class Sounds 
{
    public SoundType soundType;
    public AudioClip audioClip;
    public bool loop;
}
