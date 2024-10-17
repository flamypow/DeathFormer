using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectableNav : MonoBehaviour
{
  [SerializeField] public List<GameObject> prefabs;     
private Transform player;             
[SerializeField] public TextMeshProUGUI soulCollectedText;  
private GameObject _closestSoul;                     
private float closestDistance;                      

void Update()
{
    if (player == null)
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            return;
        }
    }
    FindClosestPrefab();
    DisplayClosestPrefab();
}

void FindClosestPrefab()
{
    closestDistance = Mathf.Infinity; 
    _closestSoul = null;              

    for (int i = prefabs.Count - 1; i >= 0; i--)
    {
        GameObject prefab = prefabs[i];

      
        if (prefab == null || !prefab.activeInHierarchy)
        {
           
            prefabs.RemoveAt(i);
            continue;
        }
        
        float distanceToPrefab = Vector2.Distance(player.position, prefab.transform.position);
        
        if (distanceToPrefab < closestDistance)
        {
            closestDistance = distanceToPrefab;
            _closestSoul = prefab;
        }
    }
}

void DisplayClosestPrefab()
{
    if (_closestSoul != null)  
    {
        soulCollectedText.text = "Closest Soul: " + "\nDistance: " + Mathf.FloorToInt(closestDistance).ToString();
    }
    else
    {
        soulCollectedText.text = "All Souls Collected";
    }
}
    public void OnSoulCollected(GameObject collectedSoul)
    {
       
        if (prefabs.Contains(collectedSoul))
        {
            prefabs.Remove(collectedSoul);
            collectedSoul.SetActive(false); 
        }
        
        FindClosestPrefab();
        DisplayClosestPrefab();
    }
}
