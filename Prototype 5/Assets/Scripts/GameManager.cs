/*
 * Stefanos Charalampous
 * GameManager.cs
 * Assignment
 * This script manages the core gameplay, including spawning targets, updating the score, and handling game over states.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    private float spawnRate = 1.0f;
    private int score;
    public bool isGameActive;
    public GameObject titleScreen;

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        StartCoroutine(SpawnTarget());
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
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            if (targets.Count > 0)
            {
                int index = Random.Range(0, targets.Count);
                Instantiate(targets[index]);
            }
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}