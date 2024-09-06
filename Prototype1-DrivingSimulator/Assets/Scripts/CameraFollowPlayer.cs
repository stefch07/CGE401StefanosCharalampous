/*
* Stefanos Charalampous
* Assignment 2
* This script makes the camera follow the player
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset = new Vector3(0, 5, -7);

    // Update the camera's position after physics calculations
    void FixedUpdate()
    {
        transform.position = player.transform.position + offset;   
    }
}