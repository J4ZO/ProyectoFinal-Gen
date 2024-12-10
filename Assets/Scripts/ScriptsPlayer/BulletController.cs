using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody bulletRb;
    public float bulltPower = 0f;
    public float lifeTime = 10f;
    public float damageAmount = 25f;

    private float time = 0f;
    private EnemyController healthEnemy;
    [SerializeField] private AudioClip hitSound;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.velocity = transform.forward * bulltPower;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (time >= lifeTime)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) 
    { if (other.CompareTag("Enemy"))
        {
            EnemyController healthEnemy = other.GetComponentInChildren<EnemyController>();
            AudioManager.Instance.PlaySFX(hitSound);
            healthEnemy.Damage(damageAmount); 
            Debug.Log("Bala impact� al enemigo");
            gameObject.SetActive(false);
        }
    
    }   
}
