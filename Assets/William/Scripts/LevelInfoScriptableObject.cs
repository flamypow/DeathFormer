using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelInfo", menuName = "SOs/LevelInfo", order = 3)]
public class LevelInfoScriptableObject : ScriptableObject
{
    [SerializeField] public GameObject defaultPlayerSpawnLocation;
    [SerializeField] public GameObject pauseMenu;
}
