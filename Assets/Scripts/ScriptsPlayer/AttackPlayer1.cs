using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer1 : MonoBehaviour
{
    private EnemyController healthEnemy;
    [SerializeField] GameObject gun; 
    
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
        
    }

    private void AtacarConPunos()
    {
        // Se debe poner un colisionador a los puños para que al entrar en contacto con el enemigo se ejecute el daño
        healthEnemy.Damage(5f);
        Debug.Log("Atacando con punos");
    }

    private void AtacarConPistola()
    {
        // Se debe poner un colisionador a las balas para que al entrar en contacto con el enemigo se ejecute el daño
        healthEnemy.Damage(25f);
        Debug.Log("Atacando con punos");
        
    }

    //Organizar que desactive y active, ahi puse para ocultar la pistola, como ejemplo
    private void HideGun()
    {
        gun.SetActive(false);
    }
}
