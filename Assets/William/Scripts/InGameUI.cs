using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private int startingLives;
    [SerializeField] private UISpritesScriptableObject spritesSO;
    [SerializeField] private GameObject parentObject;
    [SerializeField] private GameObject livesObject;
    private int livesSpent;
    Queue<GameObject> lives = new Queue<GameObject>();

    public void Start()
    {
        for (int i = 0; i < startingLives; i++)
        {
            playerGainLife();
        }
    }
    public void playerDeath()
    {
        if (lives.Count != 0)
        {
            GameObject imageref = lives.Dequeue();
            imageref.GetComponent<Image>().sprite = spritesSO.playerDead;
        }
    }

    public void playerGainLife()
    {
        GameObject newImage = Instantiate(livesObject, parentObject.transform);
        newImage.transform.SetSiblingIndex(0);
        lives.Enqueue(newImage);
    }
}
