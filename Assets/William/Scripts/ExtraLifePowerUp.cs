using Code.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifePowerUp : Collectibles
{
    protected override void OnCollected()
    {
        AudioManager.Instance.PlayAudio(AudioType.GAINLIFE);
        GameManager.Instance.gainExtraLive();
    }
}
