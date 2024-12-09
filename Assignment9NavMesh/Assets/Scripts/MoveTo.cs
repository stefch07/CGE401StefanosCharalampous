/*
 * Stefanos Charalampous
 * MoveTo.cs
 * Assignment 9
 * Moves a NavMeshAgent to a specified goal transform.
 */

using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public Transform goal;

    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        if (agent != null && goal != null)
        {
            agent.destination = goal.position;
        }
    }

    void Update()
    {
    }
}