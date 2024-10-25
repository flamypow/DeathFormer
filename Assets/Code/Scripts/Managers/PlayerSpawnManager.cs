using Code.Scripts.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Scripts.Managers
{
    public class PlayerSpawnManager : Singleton<PlayerSpawnManager>
    {
        [SerializeField] private Transform _defaultSpawn;
        [SerializeField] private Transform _currentSpawn;
        [SerializeField] private GameObject _playerPrefab;

        [SerializeField] private GameObject _currentPlayer;
        protected override void Initialize()
        {
            _currentSpawn = _defaultSpawn;
            if (_playerPrefab != null)
            {
                Invoke("SpawnPlayer", 1f);
            }

        }

        private void SpawnPlayer()
        {
            if (_currentPlayer == null)
            {
                _currentPlayer = Instantiate(_playerPrefab, _currentSpawn);
                // Find the collect NAv
                // Tell it the player information
            }
        }

        public void SpawnPlayer(Transform spawnTransform)
        {
            if (_currentPlayer == null)
            {
                if (spawnTransform == null)
                {
                    SpawnPlayer();
                }
                else {
                    _currentPlayer = Instantiate(_playerPrefab, spawnTransform);
                }
                
            }
        }
        void OnLevelWasLoaded()
        {
            _defaultSpawn = GameObject.FindGameObjectWithTag("DefaultRespawn").transform;
            Initialize();
        }

        public void ChangeSpawnLocation(Transform newSpawnLocation)
        {
            _currentSpawn?.GetComponent<RespawnPoint>()?.TurnOffSpawnPoint();
            _currentSpawn = newSpawnLocation;
        }



    }
}