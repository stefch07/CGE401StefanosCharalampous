/*
* Stefanos Charalampous
* Assignment 2
* TriggerZoneX script
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneX : MonoBehaviour
{
  private bool triggered = false;

 private void OnTriggerEnter(Collider other)
 {
    if (other.CompareTag("Player") && !triggered)
    {
        triggered = true;
        ScoreManagerX.score++; 
    }
 }
}
