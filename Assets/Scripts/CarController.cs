using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    public InputAction inputAction; // To detect left/right arrow keystroke inputs

    public Transform leftEdgeOfRoad; // Location of the left edge
    public Transform rightEdgeOfRoad; // Location of the right edge

    public float smoothSpeed = 10f; // Speed for smooth movement
    private float targetXPosition; // Target position for the player

    // Called every time the GameObject is enabled in the scene.
    private void OnEnable()
    {
        inputAction.Enable();
    }

    // Called every time the GameObject is disabled in the scene.
    private void OnDisable()
    {
        inputAction.Disable();
    }

    private void Awake()
    {
        targetXPosition = transform.position.x;
    }

    private void Update()
    {
        // Get the player's input
        float inputX = inputAction.ReadValue<Vector2>().x;

        // Determine the target x position based on input
        if (inputX != 0)
        {
            targetXPosition = inputX < 0
                ? leftEdgeOfRoad.position.x + 2.5f
                : rightEdgeOfRoad.position.x - 1.5f;
        }

        // Smoothly move towards the target position
        float smoothedX = Mathf.Lerp(transform.position.x, targetXPosition, smoothSpeed * Time.deltaTime);
        transform.position = new Vector2(smoothedX, transform.position.y); //Settle at the target position
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyCar"))
        {
            Destroy(other.gameObject); //Destroy the enemy
            GameManager.instance.GameOver(); //Game is over

            KillAllRoadDividersAndEnemyCars(); //Clean up the game space.
        }
    }

    //This function kill all road dividers and enemy cars which are spawned and yet to be killed.
    private void KillAllRoadDividersAndEnemyCars()
    {
        // Define tags to destroy
        string[] tagsToDestroy = { "RoadDivider", "EnemyCar" };

        // Loop through each tag and destroy objects
        foreach (string tag in tagsToDestroy)
        {
            // Find all game objects with the current tag
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);

            // Destroy each object with the tag
            foreach (GameObject obj in objectsWithTag)
            {
                Destroy(obj);
            }
        }
    }

}
