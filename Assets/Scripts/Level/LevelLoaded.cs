using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoaded : MonoBehaviour
{
    [SerializeField] private string nameOfMusicForLevel;
    void Start()
    {
        AudioSingletone.instance.SwitchMusic(nameOfMusicForLevel);
    }

}
