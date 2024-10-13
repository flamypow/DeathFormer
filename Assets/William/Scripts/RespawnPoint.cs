using Code.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class RespawnPoint : MonoBehaviour
{
    [SerializeField] private Sprite nonActiveSprite;
    [SerializeField] private Sprite activeSprite;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerSpawnManager.Instance.ChangeSpawnLocation(this.transform);
        this.GetComponent<SpriteRenderer>().sprite = activeSprite;
    }

    public void TurnOffSpawnPoint()
    {
        this.GetComponent<SpriteRenderer>().sprite = nonActiveSprite;
    }
}
