using UnityEngine;

public class Rörelse : MonoBehaviour
{
    public float speed = 5f;         // Movement speed
    private Rigidbody2D rb;
    private float moveInput;
    private bool facingRight = true; // Track which way the player is facing

    SpriteRenderer rend;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Get horizontal input (-1 for left, 1 for right)
        moveInput = Input.GetAxisRaw("Horizontal");

        // Move the player
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        // Flip the player if moving in the opposite direction
        if (facingRight == false && moveInput > 0)
        {
           rend.flipX = true;
            facingRight = true;
           // Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            rend.flipX = false;
            facingRight = false;
            //Flip();
        }
    }

    void Flip()
    {
        // Switch the way the player is facing
        facingRight = !facingRight;

        // Multiply the player's x scale by -1 to flip the sprite
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}