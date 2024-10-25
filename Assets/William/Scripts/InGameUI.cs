using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private int startingLives;
    private int currentTotalLives;
    [SerializeField] private UISpritesScriptableObject spritesSO;
    [SerializeField] private GameObject parentObject;
    [SerializeField] private GameObject livesObject;
    Queue<GameObject> lives = new Queue<GameObject>();
    Queue<GameObject> livesSpent = new Queue<GameObject>() ;

    public void Start()
    {
        currentTotalLives = startingLives;
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
            livesSpent.Enqueue(imageref);
        }
    }

    public void ResetCorpse()
    {
        while (lives.Count > 0)
        { Destroy(lives.Dequeue()); }
        while (livesSpent.Count > 0)
        { Destroy(livesSpent.Dequeue()); }
        for (int i = 0; i < currentTotalLives; i++)
        {
            playerGainLife();
        }
    }
    public void playerGainLife()
    {
        GameObject newImage = Instantiate(livesObject, parentObject.transform);
        newImage.transform.SetSiblingIndex(0);
        lives.Enqueue(newImage);
        
    }

    public void playerGainAdditionalLife()
    {
        currentTotalLives += 1;
        playerGainLife();
    }
}
