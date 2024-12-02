/*
 * Stefanos Charalampous
 * DifficultyButtonX.cs
 * Assignment
 * This script handles difficulty selection for the secondary game version by interacting with GameManagerX.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonX : MonoBehaviour
{
    private Button button;
    private GameManagerX gameManagerX;
    public int difficulty;

    void Start()
    {
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        gameManagerX.StartGame(difficulty);
    }
}