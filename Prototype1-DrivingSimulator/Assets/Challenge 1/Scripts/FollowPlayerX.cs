/*
* Stefanos Charalampous
* Assignment 2
* Makes the camera follow the player/plane
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset = new Vector3(0, 5, -10);  
    void Start()
    {
        offset = transform.position - plane.transform.position;
    }
    void Update()
    {
        transform.position = plane.transform.position + offset;
    }
}