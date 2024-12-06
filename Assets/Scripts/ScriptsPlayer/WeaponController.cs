using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform shootSpawn; 
    public GameObject bulletPrefab; 
    public float bulletPower = 20f; 
    private Animator animator; 

    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        RaycastHit cameraHit;

        // Rayo desde la cámara hacia adelante
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out cameraHit))
        {
            Vector3 shootDirection = cameraHit.point - shootSpawn.position;
            shootSpawn.rotation = Quaternion.LookRotation(shootDirection);

            // Detectar clic izquierdo del ratón
            if (Input.GetKey(KeyCode.Mouse0))
            {
                // Si se presiona Shift al mismo tiempo, dispara; de lo contrario, golpea con puños
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    Shoot();
                }
                else
                {
                    Punch();
                }
            }
        }
    }

    public void Shoot()
    {
        // Instanciar la bala en el punto de salida y con la rotación adecuada
        GameObject bullet = Instantiate(bulletPrefab, shootSpawn.position, shootSpawn.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(shootSpawn.forward * bulletPower, ForceMode.Impulse);
        Debug.Log("Disparando bala");
    }

    public void Punch()
    {
        // Activar la animación de ataque con puños
        animator.SetTrigger("Punch");
        Debug.Log("Atacando con puños");

    }
}


