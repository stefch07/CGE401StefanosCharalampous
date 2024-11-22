using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;

    public int difficulty; // Difficulty level to pass to the GameManager

    void Start()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(SetDifficulty);
        }

        // Corrected: Find single GameManager by tag
        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");

        if (gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }
        else
        {
            Debug.LogError("GameManager not found! Ensure it is tagged correctly in the scene.");
        }
    }

    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");

        if (gameManager != null)
        {
            gameManager.StartGame(difficulty); // Pass difficulty level to GameManager
        }
        else
        {
            Debug.LogError("GameManager reference is missing.");
        }
    }
}