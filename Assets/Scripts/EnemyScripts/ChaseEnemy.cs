using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseEnemy : State
{
    private Transform player;

    private NavMeshAgent agent;
    private AttackState attack; // call attack state

    private EnemyController die;

    [SerializeField] private bool isInRange;

    
    private Animator animator;
    private HealthController healthPlayer;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        attack = GetComponent<AttackState>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        die = GetComponentInChildren<EnemyController>();
        healthPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPlayer.GetDie()) 
        {
            agent.isStopped = true;
            agent.ResetPath();
            animator.ResetTrigger("Run");
            return; 
        }

        if(!die.GetDie())
        {
            agent.SetDestination(player.position);
            animator.SetTrigger("Run");
        }
    }

    public override State RunCurrentState()
    {
        if(isInRange) // Change Attack State
        {
            return attack;
        }
        else
        {
            return this;
        }
        
    }

    private void StopChasing()
    {
        if (!agent.isStopped)
        {
            agent.isStopped = true; 
            agent.ResetPath(); 
        }
        animator.ResetTrigger("Run"); 
        animator.SetTrigger("Idle"); 
    }

    private void OnTriggerEnter(Collider other) 
    {
        isInRange = other.CompareTag("Player") ? true : false;
    }
    private void OnTriggerExit(Collider other) 
    {
        isInRange = other.CompareTag("Player") ? false : true;
    }
}
