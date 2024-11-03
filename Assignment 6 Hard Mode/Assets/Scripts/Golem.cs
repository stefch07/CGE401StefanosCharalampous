using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
    protected int damage;

    protected override void Awake()
    {
        base.Awake();
        health = 120;
        GameManager.instance.score += 2;
    }

    protected override void Attack(int amount)
    {
        Debug.Log("Golem Attacks!");
    }
    public override void TakeDamage(int amount)
    {
        Debug.Log("You took " + amount + " points of damage!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}