using Code.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbable : MonoBehaviour
{
    public bool CanClimb { get; private set; }
    [SerializeField] private bool flipPlayer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            ((PlayerController)other.gameObject.GetComponent<PlayerController>()).ChangeState(PlayerStates.Hanging);
            other.gameObject.transform.SetParent(this.transform);
            if (flipPlayer)
            {
                //other.gameObject.transform.localScale = new Vector3(other.gameObject.transform.localScale.x * -1, other.gameObject.transform.localScale.y, other.gameObject.transform.localScale.z);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            if (flipPlayer)
            {
                collision.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        //CanClimb = false;   
    }
}
