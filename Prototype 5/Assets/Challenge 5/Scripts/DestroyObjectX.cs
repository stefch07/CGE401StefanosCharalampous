/*
 * Stefanos Charalampous
 * DestroyObjectX.cs
 * Assignment
 * This script destroys objects after a set time.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectX : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2);
    }
}