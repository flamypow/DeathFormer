using Code.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : Collectibles
{
    protected override void OnCollected()
    {
        GameManager.Instance.gainSoul();
    }
}
