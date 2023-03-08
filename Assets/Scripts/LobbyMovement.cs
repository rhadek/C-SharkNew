using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyMovement : MonoBehaviour
{
    public float speed = 5f; // Movement speed of the character
    public float jumpForce = 7f; // Jump force of the character

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move left and right with arrow keys
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Jump with spacebar
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the player is on the ground
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
