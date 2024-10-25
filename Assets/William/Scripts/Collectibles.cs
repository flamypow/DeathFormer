using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Collectibles : MonoBehaviour
{
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        OnCollected();
        Destroy(this.gameObject);
    }

    protected virtual void OnCollected()
    {
        Debug.Log("BaseCollectibles.ONCollected");
    }
}
