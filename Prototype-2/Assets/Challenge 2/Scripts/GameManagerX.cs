using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text healthText;
    private int score = 0;
    private int health = 5;
    private bool gameOver = false;

    private void Start()
    {
        // Check if scoreText and healthText are assigned before using them
        if (scoreText != null && healthText != null)
        {
            scoreText.text = "Score: " + score;
            healthText.text = "Health: " + health;
        }
    }

    private void Update()
    {
        // Check if the game is over and player presses "R" to restart
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reloads the current scene
        }
    }

    public void IncrementScore()
    {
        // Don't update score if the game is over
        if (gameOver) return;

        score++;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }

        // Win condition
        if (score >= 5)
        {
            gameOver = true;
            // Handle win condition (e.g., show win UI here)
        }
    }

    public void DecrementHealth()
    {
        // Don't update health if the game is over
        if (gameOver) return;

        health--;
        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }

        // Loss condition
        if (health <= 0)
        {
            gameOver = true;
            // Handle game over (e.g., show game over UI here)
        }
    }
}