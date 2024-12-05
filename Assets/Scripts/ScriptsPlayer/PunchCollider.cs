using UnityEngine;

public class PunchCollider : MonoBehaviour
{
    public float damageAmount = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController healthEnemy = other.GetComponent<EnemyController>();
            if (healthEnemy != null)
            {
                healthEnemy.Damage(damageAmount);
                Debug.Log("Atacando con puños");
            }
        }
    }
}

