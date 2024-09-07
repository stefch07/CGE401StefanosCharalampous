/*
* Stefanos Charalampous
* Assignment 2
* This script makes the camera smoothly follow the player from behind
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset = new Vector3(0, 5, -7);
    private Vector3 velocity = Vector3.zero; // To be used by SmoothDamp
    public float smoothTime = 0.3f; // Adjust for smoothness

    // Update the camera's position after physics calculations
    void FixedUpdate()
    {
        // Rotate the offset based on the player's rotation
        Vector3 rotatedOffset = player.transform.rotation * offset;

        // Target position for the camera
        Vector3 targetPosition = player.transform.position + rotatedOffset;

        // Smoothly move the camera towards the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // Make the camera look at the player
        transform.LookAt(player.transform);
    }
}