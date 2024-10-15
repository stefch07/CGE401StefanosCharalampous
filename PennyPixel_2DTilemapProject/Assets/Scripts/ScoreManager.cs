/*
* Stefanos Charalampous
* Assignment 2
* ScoreManager script
*/
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static bool gameOver = false;
    public static bool won = false;
    public static int score = 0;
    public Text textbox;

    void Start()
    {
        ResetGame();
    }

    void Update()
    {
        if (!gameOver)
        {
            textbox.text = "Score: " + score;
        }

        if (score >= 10)
        {
            WinGame();
        }

        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public static void IncrementScore()
    {
        score++;
    }

    private void WinGame()
    {
        won = true;
        gameOver = true;
        textbox.text = "You win!\nPress R to Try Again!";
    }

    public void ResetGame()
    {
        gameOver = false;
        won = false;
        score = 0;
    }
}