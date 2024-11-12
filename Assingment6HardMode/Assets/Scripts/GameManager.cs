/*
 * Stefanos Charalampous
 * GameManager.cs
 * Assignment 6 - Hard Mode
 * Manages game states, including level loading, unloading, pausing, and win condition based on item collection.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;  // Tracks the player's score for collected items
    public int requiredScore;  // The score needed to complete the current level
    public GameObject pauseMenu;
    private string CurrentLevelName = string.Empty;
    
    #region Singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Lock the cursor when the game starts
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError("Trying to instantiate a second instance of singleton GameManager");
        }
    }
    #endregion

    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + levelName);
            return;
        }
        CurrentLevelName = levelName;

        // Set requiredScore based on level name
        if (levelName == "Level1")
        {
            requiredScore = 5;  // Set the number of items required for Level 1
        }
        else if (levelName == "Level2")
        {
            requiredScore = 7;  // Set the number of items required for Level 2
        }
        else if (levelName == "Level3")
        {
            requiredScore = 10;  // Set the number of items required for Level 3
        }
    }

    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + levelName);
            return;
        }
        CurrentLevelName = string.Empty;
    }

    public void UnloadCurrentLevel()
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(CurrentLevelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + CurrentLevelName);
            return;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor when the game is paused
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;  // Lock cursor again when unpausing
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 0f)
                Unpause();
            else
                Pause();
        }

        // Check if the player has collected enough items to win the level
        if (score >= requiredScore)
        {
            WinLevel();
        }
    }

    private void WinLevel()
    {
        Debug.Log("Level Complete!");

        // Unload the current level and load the next one
        if (CurrentLevelName == "Level1")
        {
            UnloadLevel("Level1");
            LoadLevel("Level2");
        }
        else if (CurrentLevelName == "Level2")
        {
            UnloadLevel("Level2");
            LoadLevel("Level3");
        }
        else if (CurrentLevelName == "Level3")
        {
            Debug.Log("Game Complete! You've completed all levels.");
            // Implement any end game logic here, such as returning to the main menu
            UnloadLevel("Level3");
        }

        // Reset score for the next level
        score = 0;
    }
}