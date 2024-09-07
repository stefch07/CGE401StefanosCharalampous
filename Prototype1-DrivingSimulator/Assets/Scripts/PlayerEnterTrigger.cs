/*
* Stefanos Charalampous
* Assignment 2
* TriggerZone
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class PlayerEnterTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerZone"))
        {
            // textbox.text = "You win!";
            ScoreManager.score++;
        }
    }
}