using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [SerializeField] float speed = 3;
    Rigidbody2D rb;
    Vector2 Inputdir;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        rb.velocity = Inputdir.normalized * speed;
    }

    public void SetInputDir(InputAction.CallbackContext context)
    {
        Inputdir = context.ReadValue<Vector2>();
    }
}
