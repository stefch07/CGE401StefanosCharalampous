/*
* Stefanos Charalampous
* Assignment 3
* Moves objects forward
*/
using UnityEngine;

public class MoveForwardX : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}