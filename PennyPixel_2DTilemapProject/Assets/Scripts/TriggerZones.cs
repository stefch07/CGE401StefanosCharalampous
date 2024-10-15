/*
* Stefanos Charalampous
* Assignment 5A
* This script increments the score when the player enters the trigger zone and deactivates the collectible.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZones : MonoBehaviour
{
    bool active = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.gameObject.tag == "Player")
        {
            active = false;

            ScoreManager.score++;
            gameObject.SetActive(false);
        }
    }
}