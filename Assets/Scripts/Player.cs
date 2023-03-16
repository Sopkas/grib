using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveIntput;
    private Vector2 moveVelocity;
    private Animator animator;

    private bool facingRight = true;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

     void Update() 
     {
        moveIntput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveIntput.normalized * speed;

        if(moveIntput.x == 0) 
        {
            animator.SetBool("isRunning", false);
        } else 
        {
            animator.SetBool("isRunning", true);
        }

        if(!facingRight && moveIntput.x > 0) 
        {
            Flip();
        } 
        else if(facingRight && moveIntput.x < 0) 
        {
            Flip();
        }

    }

     void FixedUpdate() 
     {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void Flip() 
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


}
