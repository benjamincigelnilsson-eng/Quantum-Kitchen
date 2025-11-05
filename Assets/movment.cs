using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Hastigheten på karaktären
    private Rigidbody2D rb;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    [System.Obsolete]
    void Update()
    {
        // Läs in horisontell input (A/D eller vänster/höger piltangent)
        moveInput = Input.GetAxisRaw("Horizontal");

        // Flytta karaktären
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
}
