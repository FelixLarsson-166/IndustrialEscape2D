using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class move : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] float jumpforce = 3;
    [SerializeField] ContactFilter2D grounFilter;
    Vector2 inputDir = Vector2.zero;
    CapsuleCollider2D coll;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sprite;
    bool grounded = false;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Run", inputDir.x != 0);
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("DirY", rb.velocity.y);

        grounded = coll.IsTouching(grounFilter);

        if(jump)
        {
            Jump();
        }

        rb.velocity = new Vector2(inputDir.x * speed, rb.velocity.y);
    }
    public void SetMoveDir(InputAction.CallbackContext context)
    {
        inputDir = context.ReadValue<Vector2>();
        if (inputDir.x > 0 && sprite.flipX)
        {
            sprite.flipX = false;
        }
        if (inputDir.x < 0 && !sprite.flipX)
        {
            sprite.flipX = true;
        }
    }
    public void ActivateJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jump = true;
        }
        if (context.performed || context.canceled)
        {
            jump = false;
        }
    }
    private void Jump()
    {
        if(grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpforce,ForceMode2D.Impulse);
            jump = false;
        }
    }
}