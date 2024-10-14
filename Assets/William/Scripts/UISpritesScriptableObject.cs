using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UISpriteInfo", menuName = "SOs/UISpriteInfo", order = 3)]
public class UISpritesScriptableObject : ScriptableObject
{
    [SerializeField] public Sprite playerRunning;
    [SerializeField] public Sprite playerDead;
}
