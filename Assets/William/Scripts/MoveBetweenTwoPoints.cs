using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MoveBetweenTwoPoints : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private GameObject objectToMove;
    [SerializeField] private Vector3 pointA;
    [SerializeField] private Vector3 pointB;
    private Vector3 worldPointA;
    private Vector3 worldPointB;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float movePrecision = 0.4f;

    private bool movingTowardsA;
    [SerializeField] private bool shouldMove;
    [Header("Idle")]
    private bool idling = false;
    [SerializeField] private float idleDuration;
    private float idleTimer;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(this.transform.position + pointA, 0.1f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.transform.position + pointB, 0.1f);
    }

    private void Start()
    {
        worldPointA = this.transform.position + pointA;
        worldPointB = this.transform.position + pointB;
    }

    private void Update()
    {
        if (shouldMove)
        {
            MoveAndIdle();
        }

    }
    void MoveAndIdle()
    {
        if (!idling)
        {
            if (movingTowardsA)
            {
                objectToMove.transform.position = Vector2.MoveTowards(objectToMove.transform.position, worldPointA, moveSpeed * Time.deltaTime);
                CheckIfArrived(worldPointA);
            }
            else {
                objectToMove.transform.position = Vector2.MoveTowards(objectToMove.transform.position, worldPointB, moveSpeed * Time.deltaTime);
                CheckIfArrived(worldPointB);
            }
        }
        else
        {
            idleTimer -= Time.deltaTime;
            if (idleTimer < 0f)
            {
                idling = false;
            }
        }
    }

    void CheckIfArrived(Vector2 destinationPosition)
    {

        if (Vector2.Distance(objectToMove.transform.position, destinationPosition) < movePrecision)
        {
            idling = true;
            idleTimer = idleDuration;
            if (movingTowardsA)
            {
                movingTowardsA = false;
            }
            else
            {
                movingTowardsA = true;
            }
        }
    }
}

