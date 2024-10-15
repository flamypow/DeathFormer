using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjstaclePatrol : MonoBehaviour
{
    [SerializeField]  List<Transform> patrolPoints = new List<Transform>();  
    [SerializeField] public float moveSpeed = 2f;      
    private int currentPointIndex = 0; 

    void Update()
    {
        PatrolMovement();
    }

    void PatrolMovement()
    {
        if (patrolPoints.Count == 0) return;
        
        Transform targetPoint = patrolPoints[currentPointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

      
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Count;
        }
    }
}
