using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private ChaseEnemy chase; // call attack state
    [SerializeField] private bool isAttacking;
    private HealthController healthPlayer;
    private Animator animator;

    void Start()
    {
        chase = GetComponent<ChaseEnemy>();
        animator = GetComponent<Animator>();
        healthPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
        
    }
    public override State RunCurrentState()
    {
        if(isAttacking && !healthPlayer.GetDie())
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
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(!healthPlayer.GetDie())
        {
            animator.SetTrigger("Attack");
        }
        
        isAttacking = other.CompareTag("Player") ? true : false;
    }
    private void OnTriggerExit(Collider other) 
    {
        isAttacking = other.CompareTag("Player") ? false : true;
    }
}