using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text healthText;
    private int score = 0;
    private int health = 5;

    private void Start()
    {
        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + health;
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;

        if (score >= 5)
        {
            Debug.Log("You Win!");
            // Handle win condition
        }
    }

    public void DecrementHealth()
    {
        health--;
        healthText.text = "Health: " + health;

        if (health <= 0)
        {
            Debug.Log("Game Over");
            // Handle loss condition
        }
    }
}