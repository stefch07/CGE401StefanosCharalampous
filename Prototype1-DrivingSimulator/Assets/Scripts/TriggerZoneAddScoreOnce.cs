/*
* Stefanos Charalampous
* Assignment 2
* This script increments the score
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneAddScoreOnce : MonoBehaviour
{
 private bool triggered = false;

 private void OnTriggerEnter(Collider other)
 {
    if (other.CompareTag("Player") && !triggered)
    {
        triggered = true;
        ScoreManager.score++; 
    }
 }
}
