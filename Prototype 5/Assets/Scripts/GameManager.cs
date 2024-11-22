using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets; // List of target prefabs to spawn
    public TextMeshProUGUI scoreText; // UI text to display the score
    public TextMeshProUGUI gameOverText; // UI text for game over
    public Button restartButton; // Button to restart the game
    private float spawnRate = 1.0f;  // Time interval between spawns
    private int score; // Variable to track the score
    public bool isGameActive; // Tracks if the game is active
    public GameObject titleScreen;

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true; // Game starts as active
        spawnRate = 2.0f / difficulty; // Adjust spawn rate based on difficulty
        score = 0; // Initialize the score
        UpdateScore(0); // Update the score display with the initial value
        StartCoroutine(SpawnTarget()); // Start spawning targets
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Start()
    {
        // Ensure game over and restart button are hidden at start
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    // Ends the game
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false; // Stop the game
    }

    // Coroutine to spawn targets
    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            // Wait for the defined spawn rate before spawning the next object
            yield return new WaitForSeconds(spawnRate);

            if (targets.Count > 0) // Ensure the targets list is not empty
            {
                // Select a random target from the list
                int index = Random.Range(0, targets.Count);

                // Instantiate the selected target at its predefined position and rotation
                Instantiate(targets[index]);
            }
        }
    }

    // Method to update the score
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd; // Increment the score
        scoreText.text = "Score: " + score; // Update the score text
    }
}