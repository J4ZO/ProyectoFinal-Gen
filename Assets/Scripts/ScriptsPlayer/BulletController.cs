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
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        sound = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        bulletRb.velocity = transform.forward * bulltPower;
        try
        {
            healthEnemy = GameObject.FindGameObjectWithTag("Enemy").GetComponentInChildren<EnemyController>();
        }
        catch (System.Exception)
        {
        }
        
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
            sound.PlayOneShot(hitSound);
            healthEnemy.Damage(damageAmount); 
            Debug.Log("Bala impact� al enemigo");
            gameObject.SetActive(false);
        }
    
    }   
}
