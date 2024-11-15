using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text startText; // Reference to Start Text

    void Start()
    {
        Time.timeScale = 0; // Pause the game initially
        startText.gameObject.SetActive(true); // Display "Press Spacebar to Start"
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startText.gameObject.SetActive(false); // Hide start text
            Time.timeScale = 1; // Resume the game
        }
    }
}