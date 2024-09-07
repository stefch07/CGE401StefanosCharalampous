/*
* Stefanos Charalampous
* Assignment 2
* This script makes the player lose if falls off the road
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class LoseOnFall : MonoBehaviour
{
    
    void Update()
    {
        if(transform.position.y < -1)
        {
            //textbox.text = "You lose!";
            ScoreManager.gameOver = true;
        }
    }
}
