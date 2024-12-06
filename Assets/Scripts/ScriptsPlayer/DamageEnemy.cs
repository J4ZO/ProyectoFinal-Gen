using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField] private EnemyController healthEnemy;
    [SerializeField] private float damageAmount = 5f;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enemy"))
        {
            healthEnemy.Damage(damageAmount);
        }
    }
}