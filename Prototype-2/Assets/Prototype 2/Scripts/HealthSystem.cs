/*
* Stefanos Charalampous
* Assignment 3
* Manages player health and UI display
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Include this for scene management

public class HealthSystem : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public List<Image> hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public bool gameOver = false;

    public GameObject gameOverText;

    void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        UpdateHearts();

        if (health <= 0)
        {
            gameOver = true;
            gameOverText.SetActive(true);
            CheckForRestart(); // Call the method to check for restart input
        }
    }

    public void TakeDamage()
    {
        if (gameOver) return;

        health--;
        UpdateHearts();
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            hearts[i].enabled = i < maxHealth;
        }
    }

    private void CheckForRestart() // Method to check if the player wants to restart
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reloads the current scene
        }
    }
}