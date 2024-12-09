using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    private Animator animator;
    private EnemyController healthEnemy;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject shootBulletPos;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private float bulletPower = 20f;
    public float damageAmount = 5f;
    private bool gunActive = false;
    private bool isPunchingEnemy;
    [SerializeField] private AudioClip punchSound;
    [SerializeField] private AudioClip shootSound;
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        try
        {
            healthEnemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
        }
        catch (System.Exception)
        {
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (gunActive) 
            {
                AtacarConPistola();
            }
            else 
            {
                AtacarConPunos();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        { 
            ToggleGun();
        }
    }

    private void AtacarConPunos()
    {
        animator.SetTrigger("Attacking");
        if(isPunchingEnemy)
        {
            sound.PlayOneShot(punchSound);
        }


        if (healthEnemy != null) 
        { 
            healthEnemy.Damage(damageAmount); 
        }
    }


    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Enemy"))
        {
            isPunchingEnemy = true;
        }
    }   
    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Enemy"))
        {
            isPunchingEnemy = false;
        }
    }   

    private void AtacarConPistola()
    {
        animator.SetTrigger("Shoot");
        GameObject bullet = Instantiate(bulletPrefab, shootBulletPos.transform.position, shootBulletPos.transform.rotation); 
        Rigidbody rb = bullet.GetComponent<Rigidbody>(); 
        rb.AddForce(shootBulletPos.transform.forward * bulletPower, ForceMode.Impulse);
        sound.PlayOneShot(shootSound);
    }
    private void ToggleGun() 
    { 
        gunActive = !gunActive; 
        if(gunActive)
        {
            crosshair.SetActive(true);
            StartCoroutine(WaitActiveGun());
        }
        else
        {
            gun.SetActive(false);
            crosshair.SetActive(false);
        }
        Debug.Log(gunActive ? "Sacando el arma" : "Guardando el arma"); 
    }

    private IEnumerator WaitActiveGun() 
    {
        animator.SetTrigger("isGunPick");
        yield return new WaitForSeconds(0.3f); 
        gun.SetActive(true); 
    }
}
