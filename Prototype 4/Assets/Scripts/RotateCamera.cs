/*
 * Stefanos Charalampous
 * RotateCamera.cs
 * Assignment 7
 * Handles the rotation of the camera around the player based on horizontal input.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationspeed;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationspeed * Time.deltaTime);
    }
}