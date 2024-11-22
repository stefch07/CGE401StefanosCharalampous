using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 10f;
    private float xRange = 4f;
    private float ySpawnPos = -6f;

    private GameManager gameManager; // Reference to GameManager

    public int pointValue; // Points awarded for clicking this target
    public ParticleSystem explosionParticle;

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        // Apply a randomized upward force
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        // Apply randomized torque for rotation
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        // Set the initial position with a randomized X value
        transform.position = RandomSpawnPos();

        // Attempt to find the GameManager in the scene
        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");

        if (gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }
        else
        {
            Debug.LogError("GameManager not found! Make sure it is tagged as 'GameManager'.");
        }
    }

    // Generate a random upward force
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    // Generate a random torque value for rotation
    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    // Generate a random spawn position
    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    // Destroy the target when clicked
    private void OnMouseDown()
    {
        if (gameManager != null && gameManager.isGameActive) // Ensure GameManager exists and game is active
        {
            gameManager.UpdateScore(pointValue); // Increment score by pointValue

            // Instantiate explosion particle effect
            if (explosionParticle != null)
            {
                Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            }
            else
            {
                Debug.LogWarning("ExplosionParticle is not assigned to the Target prefab.");
            }

            Destroy(gameObject); // Destroy this target
        }
    }

    // Destroy the target when it enters a trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad")) // If not a "Bad" target
        {
            if (gameManager != null && gameManager.isGameActive) // Ensure GameManager exists and game is active
            {
                gameManager.GameOver(); // Trigger game over
            }
        }

        Destroy(gameObject); // Destroy this target
    }
}