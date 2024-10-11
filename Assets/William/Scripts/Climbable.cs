using Code.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbable : MonoBehaviour
{
    public bool CanClimb { get; private set; }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            ((PlayerController)other.gameObject.GetComponent<PlayerController>()).ChangeState(PlayerStates.Hanging);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CanClimb = false;   
    }
}
