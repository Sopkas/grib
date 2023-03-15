using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveIntput;
    private Vector2 moveVelocity;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

     void Update() {
        moveIntput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveIntput.normalized * speed;
    }

     void FixedUpdate() {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
