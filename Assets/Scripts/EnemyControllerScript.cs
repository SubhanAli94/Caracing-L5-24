using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerScript : MonoBehaviour
{
    Rigidbody2D rb; // Reference to the Rigidbody2D.

    private void Awake()
    {
        // Initialize the Rigidbody2D component.
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the enemy has moved below a certain threshold (y = -5).
        // If so, destroy the enemy GameObject.
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        // Set the enemy's velocity to move downward at a constant speed of 10 units per second.
        rb.velocity = Vector3.down * 10f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the enemy collides with an object tagged "PlayerCarGround".
        if (other.gameObject.CompareTag("PlayerCarGround"))
        {
            // Call the GameManager to add a score when the enemy reaches the player's ground.
            GameManager.instance.AddScore();
        }
    }
}
