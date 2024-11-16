/*
 * Stefanos Charalampous
 * GameManager.cs
 * Assignment 7
 * Manages the start screen and initial game pause until the player presses the spacebar.
 */

using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text startText;

    void Start()
    {
        Time.timeScale = 0;
        startText.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startText.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}