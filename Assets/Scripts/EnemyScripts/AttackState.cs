using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private ChaseEnemy chase; // call attack state
    [SerializeField] private bool isAttacking;
    private Coroutine attackCoroutine; 
    private Animator animator;

    void Start()
    {
        chase = GetComponent<ChaseEnemy>();
        animator = GetComponent<Animator>();
        
    }
    public override State RunCurrentState()
    {
        if(isAttacking)
        {
            AttackPlayer();
            return this; // Stay in attack state
        }
        else
        {

            return chase; // Change chase state
        }
        
        
    }


    private void AttackPlayer()
    {

        Debug.Log("Atacando al jugador");
    }

    private void OnTriggerEnter(Collider other) 
    {
        animator.SetTrigger("Attack");
        isAttacking = other.CompareTag("Player") ? true : false;
    }
    private void OnTriggerExit(Collider other) 
    {
        isAttacking = other.CompareTag("Player") ? false : true;
    }
}