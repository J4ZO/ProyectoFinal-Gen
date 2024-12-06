using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    [SerializeField] private bool isDeadPlayer;

    [SerializeField] private GameObject gameOver;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if(currentHealth <= 0f)
        {
            isDeadPlayer = true;
            StartCoroutine(WaitDie());
        }
    }

    public bool GetDie()
    {
        return isDeadPlayer;
    }

    private IEnumerator WaitDie()
    {
        if (animator != null)
        {
            animator.SetTrigger("isDie");
        }

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length); 
        gameOver.SetActive(true);
        Time.timeScale = 0f;
    }
}
