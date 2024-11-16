/*
 * Stefanos Charalampous
 * EnemyX.cs
 * Assignment 7
 * Handles enemy movement and collision with player goals.
 */

using UnityEngine;

public class EnemyX : MonoBehaviour
{
    private SpawnManagerX spawnManagerScript; // Reference to the SpawnManager script
    public float speed = 100;
    private Rigidbody enemyRb; // Rigidbody of the enemy
    public GameObject playerGoal; // The Player Goal object

    void Start()
    {
        // Assign the Rigidbody component
        enemyRb = GetComponent<Rigidbody>();
        if (enemyRb == null)
        {
            Debug.LogError("Rigidbody is missing on the Enemy object.");
        }

        // Find the SpawnManager GameObject and get its script
        GameObject spawnManagerObject = GameObject.Find("SpawnManager");
        if (spawnManagerObject != null)
        {
            spawnManagerScript = spawnManagerObject.GetComponent<SpawnManagerX>();
            if (spawnManagerScript == null)
            {
                Debug.LogError("SpawnManagerX script not found on the 'SpawnManager' GameObject.");
            }
            else
            {
                speed = spawnManagerScript.enemySpeed; // Set enemy speed from SpawnManager
            }
        }
        else
        {
            Debug.LogError("'SpawnManager' GameObject not found in the scene.");
        }

        // Find the Player Goal object
        playerGoal = GameObject.Find("Player Goal");
        if (playerGoal == null)
        {
            Debug.LogError("'Player Goal' GameObject not found in the scene.");
        }
    }

    void Update()
    {
        // If the Player Goal is valid, move the enemy toward it
        if (playerGoal != null)
        {
            Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (spawnManagerScript == null)
        {
            Debug.LogError("SpawnManagerScript is null. Make sure 'SpawnManager' exists in the scene.");
            return;
        }

        if (other.gameObject.name == "Player Goal")
        {
            // Trigger the loss condition when the enemy reaches the Player Goal
            spawnManagerScript.TriggerLossCondition();
            Destroy(gameObject);
        }
   else if (other.gameObject.name == "Enemy Goal")
{
    if (spawnManagerScript != null)
    {
        // Increment the wave count when the enemy reaches the Enemy Goal
        spawnManagerScript.IncrementWaveOnScore();
    }
    Destroy(gameObject);
}
    }
}