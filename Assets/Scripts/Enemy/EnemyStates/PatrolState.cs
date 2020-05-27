﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState
{
    private Enemy enemy;
    private float patrolTimer;
    private float patrolDuration = 25f;


    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }
    
    public void Execute()
    {
        Debug.Log("Patrol");
        Patrol();
        //
        enemy.Move();
        //
        if (enemy.Target != null && enemy.InThrowRange)
        {
            enemy.ChangeState(new RangedState());
        }
    }

    public void Exit()
    {
        
    }
    public void OnTriggerEnter(Collider2D other)
    { 
        if (other.tag == "Edge")
        {
            Debug.Log("edge");
            enemy.ChangeDirection();
        }
    }
    
    private void Patrol()
    {
        patrolTimer += Time.deltaTime;
        if (patrolTimer >= patrolDuration)
        {
            enemy.ChangeState(new IdleState());
        }
    }
}
