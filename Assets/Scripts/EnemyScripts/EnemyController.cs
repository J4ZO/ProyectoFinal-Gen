using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private float increase;
    private bool isDead;
    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        animator = enemy.GetComponent<Animator>();
    }

    public void Damage(float damage)
    {
        //animator.SetTrigger("Damage");
        Debug.Log("Quitando vida");
        currentHealth -=damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if(currentHealth <= 0f)
        {
            isDead = true;
            StartCoroutine(WaitForDie());
        }
    }

    public bool GetDie()
    {
        return isDead;
    }

    private float SetMaxHealth(float increase)
    {
        return maxHealth += increase;
    }

    IEnumerator WaitForDie()
    {
        animator.SetBool("Die",true);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + 2f);
        enemy.SetActive(false);
        Debug.Log("Muerto enemigo");
        currentHealth = SetMaxHealth(increase);
        isDead = false;
        animator.SetBool("Die",false);
    }
}
