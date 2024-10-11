using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private int playerLives = 3;
        private Queue<GameObject> corpseGameObjectQueue = new Queue<GameObject>();

        [SerializeField] PauseMenu pauseMenu;
        private bool gamePaused = false;

        [SerializeField] InGameUI gameUI;

        public void gainExtraLive()
        {
            playerLives = playerLives++;
            gameUI.playerGainLife();
        }
        public void newDeathPlatform(GameObject corpse)
        {
            corpseGameObjectQueue.Enqueue(corpse);
            gameUI.playerDeath();
            if (corpseGameObjectQueue.Count > playerLives)
            {
                Destroy(corpseGameObjectQueue.Dequeue());
            }
        }


        public void GamePause()
        {
            gamePaused = true;
            pauseMenu?.SetInnerActive(gamePaused);
        }
        public void GameUnpause()
        {
            gamePaused = false;
            pauseMenu?.SetInnerActive(gamePaused);
        }

        private void Start()
        {
            if (pauseMenu == null)
            {
                pauseMenu = GameObject.FindAnyObjectByType<PauseMenu>();
            }
        }

        void OnLevelWasLoaded()
        {
            pauseMenu = GameObject.FindAnyObjectByType<PauseMenu>();
            gameUI = GameObject.FindAnyObjectByType<InGameUI>();
        }
        void Update()
        {
            Time.timeScale = gamePaused ? 0.0f : 1.0f;
        }

        public void ChangeScene(int sceneNum) {
            SceneManager.LoadScene(sceneNum);
        }
    }
}