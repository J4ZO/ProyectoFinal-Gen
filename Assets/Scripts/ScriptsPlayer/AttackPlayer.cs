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
    public float damageAmount = 5f;


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
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                AtacarConPistola();
            }
            else 
            {
                AtacarConPunos();
            }
        }
    }

    private void AtacarConPunos()
    {
        // Se debe poner un colisionador a los puños para que al entrar en contacto con el enemigo se ejecute el daño
        animator.SetTrigger("Punch"); 
        Debug.Log("Atacando con puños");

        if (healthEnemy != null) 
        { 
            healthEnemy.Damage(damageAmount); 
            Debug.Log("Daño infligido al enemigo con puños"); 
        }
    }       

    private void AtacarConPistola()
    {
        // Se debe poner un colisionador a las balas para que al entrar en contacto con el enemigo se ejecute el daño
        GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation); 
        Rigidbody rb = bullet.GetComponent<Rigidbody>(); 
        rb.AddForce(gun.transform.forward * bulletPower, ForceMode.Impulse);
        Debug.Log("Atacando con pistola"); 
    }

    //Organizar que desactive y active, ahi puse para ocultar la pistola, como ejemplo
    private void HideGun()
    {
        gun.SetActive(false);
    }

    private IEnumerator DesactivarColisionador(Collider collider, float delay) 
    {
        yield return new WaitForSeconds(delay); collider.enabled = false; 
    }
}
