/*
 * Stefanos Charalampous
 * Golem.cs
 * Assignment 6 - Hard Mode
 * Derived enemy class with specific attack and damage methods.
 */

using UnityEngine;

public class Golem : Enemy
{
    protected int damage;

    protected override void Awake()
    {
        base.Awake();
        health = 120;
        GameManager.instance.score += 2;  // Corrected reference to GameManager
    }

    protected override void Attack(int amount)
    {
        Debug.Log("Golem Attacks!");
    }

    public override void TakeDamage(int amount)
    {
        Debug.Log("You took " + amount + " points of damage!");
    }
}