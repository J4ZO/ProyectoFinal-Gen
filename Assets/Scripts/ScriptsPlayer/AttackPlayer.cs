using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    private Animator animator;
    private EnemyController healthEnemy;
    [SerializeField] GameObject gun;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletPower = 20f;
    [SerializeField] private Collider punchCollider;
    public float damageAmount = 5f;
    private bool gunActive = true;


    // Start is called before the first frame update
    void Start()
    {
        
        try
        {
            healthEnemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
        }
        catch (System.Exception)
        {
            
            Debug.Log("Enemy desactivated");
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
            if (Input.GetKeyDown(KeyCode.R))
            { 
                ToggleGun();
            }
        }
    }

    private void AtacarConPunos()
    {
      
        animator.SetTrigger("Punch"); 
        Debug.Log("Atacando con puños");

        punchCollider.enabled = true;
        StartCoroutine(DesactivarColisionador(punchCollider, 0.5f));

        if (healthEnemy != null) 
        { 
            healthEnemy.Damage(damageAmount); 
            Debug.Log("Daño infligido al enemigo con puños"); 
        }
    }       

    private void AtacarConPistola()
    {
        punchCollider.enabled = false;
        GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation); 
        Rigidbody rb = bullet.GetComponent<Rigidbody>(); 
        rb.AddForce(gun.transform.forward * bulletPower, ForceMode.Impulse);
        Debug.Log("Atacando con pistola"); 
    }
    private void ToggleGun() 
    { 
        gunActive = !gunActive; 
        gun.SetActive(gunActive); 
        Debug.Log(gunActive ? "Sacando el arma" : "Guardando el arma"); 
    }
    private IEnumerator DesactivarColisionador(Collider collider, float delay) 
    {
        yield return new WaitForSeconds(delay); 
        collider.enabled = false; 
    }
}
