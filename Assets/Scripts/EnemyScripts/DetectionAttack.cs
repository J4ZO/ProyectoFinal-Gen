using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionAttack : MonoBehaviour
{
    private HealthController healthPlayer;
    private Animator animator;
    private bool isAttacking;
    // Start is called before the first frame update
    void Start()
    {
        healthPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(WaitForAttack());
            if(isAttacking)
            {
                healthPlayer.DamagePlayer(5f);
                animator.SetTrigger("Hit");
            }
        }
    }

    private IEnumerator WaitForAttack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(2f);
        isAttacking = false;
    }
}
