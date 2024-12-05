using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody bulletRb;
    public float bulltPower = 0f;
    public float lifeTime = 4f;
    public float damageAmount = 25f;

    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.velocity = this.transform.forward * bulltPower;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time -= Time.deltaTime;

        if (time >= lifeTime)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other) 
    { if (other.CompareTag("Enemy"))
        {
            EnemyController healthEnemy = other.GetComponent<EnemyController>();

            if (healthEnemy != null)
            {
                healthEnemy.Damage(damageAmount);
                Debug.Log("Bala impactó al enemigo");
            }
            Destroy(this.gameObject);
        }
    
    }   
}
