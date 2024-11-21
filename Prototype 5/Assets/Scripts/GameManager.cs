using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets; // List of target prefabs to spawn
    public TextMeshProUGUI scoreText; // UI text to display the score
    private float spawnRate = 1.0f;  // Time interval between spawns
    private int score; // Variable to track the score

    void Start()
    {
        score = 0; // Initialize the score
        UpdateScore(0); // Update the score display with the initial value
        StartCoroutine(SpawnTarget());
    }

    // Coroutine to spawn targets
    private IEnumerator SpawnTarget()
    {
        while (true)
        {
            // Wait for the defined spawn rate before spawning the next object
            yield return new WaitForSeconds(spawnRate);

            // Select a random target from the list
            int index = Random.Range(0, targets.Count);

            // Instantiate the selected target at its predefined position and rotation
            Instantiate(targets[index]);

            // Add 5 points each time a target is spawned
            //UpdateScore(5);
        }
    }

    // Method to update the score
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd; // Increment the score
        scoreText.text = "Score: " + score; // Update the score text
    }
}