using System.Collections.Generic;
using UnityEngine;

namespace Code.Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private int playerLives;
        private Queue<GameObject> corpseGameObjectQueue = new Queue<GameObject>();

        public void gainExtraLive()
        {
            playerLives = playerLives++;
        }
        public void newDeathPlatform(GameObject corpse)
        {
            corpseGameObjectQueue.Enqueue(corpse);
            if (corpseGameObjectQueue.Count > playerLives)
            {
                Destroy(corpseGameObjectQueue.Dequeue());
            }
        }



    }
}