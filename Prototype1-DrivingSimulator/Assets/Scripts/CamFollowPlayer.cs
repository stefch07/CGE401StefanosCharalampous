﻿/*
* Stefanos Charalampous
* Assignment 2
* This script makes the camera follow the player
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset = new Vector3(0, 7, -13);

    void Update()
    {
     transform.position = player.transform.position + offset;   
    }
}