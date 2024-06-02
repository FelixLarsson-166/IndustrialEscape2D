using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorSwitch : MonoBehaviour
{
    [SerializeField] GameObject Door;
    [SerializeField] GameObject Player;

    public void Interact(InputAction.CallbackContext context)
    {
        if (IsPlayerColliding())
        {
            DoorOpen();
        }
    }

    private bool IsPlayerColliding()
    {
        Collider2D collider = Physics2D.OverlapBox(transform.position, transform.localScale / 2, 0f);

        
            if (collider.gameObject == Player)
            {
                Debug.Log("Player is colliding with the switch");
                return true;
            }
        

        Debug.Log("Player is NOT colliding with the switch");
        return false;
    }

    public void DoorOpen()
    {
        Destroy(Door);
    }
}
