/*
 * Stefanos Charalampous
 * DifficultyButton.cs
 * Assignment
 * This script handles the difficulty selection by interacting with the GameManager to start the game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;

    public int difficulty;

    void Start()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(SetDifficulty);
        }

        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        if (gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }
    }

    void SetDifficulty()
    {
        if (gameManager != null)
        {
            gameManager.StartGame(difficulty);
        }
    }
}