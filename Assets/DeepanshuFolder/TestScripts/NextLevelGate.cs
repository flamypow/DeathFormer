using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Managers;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextLevelGate : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] 

    void Start()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
       
    }

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.collectedSouls == 3)
        {
            if (targetObject != null && !targetObject.activeSelf) 
            {
                targetObject.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(3);
        }
    }
}
