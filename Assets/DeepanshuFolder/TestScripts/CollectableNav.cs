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
      player = player == null ? GameObject.FindWithTag("Player").GetComponent<Transform>() : player;
      if (player == null)
      {
         player = GameObject.FindWithTag("Player").transform;
      }
      
      FindClosestPrefab();
      DisplayClosestPrefab();
      
   }
   void FindClosestPrefab()
   {
      closestDistance = Mathf.Infinity; 
      _closestSoul = null;              

     
      foreach (GameObject prefab in prefabs)
      {
        
         if (!prefab.activeInHierarchy) continue;
         Debug.Log("Player Pos: " + player.position);
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
         Debug.Log(closestDistance);
         soulCollectedText.text = "Closest Soul: " + "\nDistance: " + closestDistance.ToString("F2");
       
      }
      else
      {
       
         soulCollectedText.text = "No soul nearby";
      }
   }
}
