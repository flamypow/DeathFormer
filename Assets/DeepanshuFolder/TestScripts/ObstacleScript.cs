using Code.Scripts.Managers;
using Code.Scripts.Player;
using UnityEngine;
using System.Collections.Generic;
public class ObstacleScript : MonoBehaviour
{
    [SerializeField] public List<GameObject> PlatformPrefabs; 
    [SerializeField] private Transform _playerReturnLocation;
    [SerializeField] private float _timeToRespawn = 2f;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.GetComponent<PlayerController>())
        {
            ((PlayerController)other.gameObject.GetComponent<PlayerController>()).Death();

            Vector2 collisionPosition = other.transform.position;
            SpawnPlatformWhenCollide(collisionPosition);
           
          //  ((PlayerController)other.gameObject.GetComponent<PlayerController>()).Death();
            Invoke("Respawn", _timeToRespawn);
        }
    }

    private void Respawn()
    {
        PlayerSpawnManager.Instance.SpawnPlayer(_playerReturnLocation);
    }

    private void SpawnPlatformWhenCollide(Vector2 spawnPosition)
    {
        if (PlatformPrefabs.Count > 0)
        {
            int randomIndex = Random.Range(0, PlatformPrefabs.Count);
            GameObject prefabToSpawn = PlatformPrefabs[randomIndex];
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }  
}
