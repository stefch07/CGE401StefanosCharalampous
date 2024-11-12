using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static bool gameOver = false;
    public static bool won = false;
    public Text textbox;

    void Start()
    {
        gameOver = false;
        won = false;
    }

    void Update()
    {
        if (gameOver)
        {
            if (won)
            {
                textbox.text = "You reached the finish line!\nPress R to Try Again!";
            }
            else
            {
                textbox.text = "Game Over!\nPress R to Try Again!";
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    // Call this method when the player reaches the finish line
    public void WinGame()
    {
        won = true;
        gameOver = true;
    }

    // Optional: Call this method if you want to trigger game over in other cases
    public void GameOver()
    {
        gameOver = true;
    }
}