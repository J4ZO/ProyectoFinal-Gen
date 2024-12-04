using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public float speedMovement = 5.0f;
    public float speedRotate = 200.0f;

    private Animator animator;
    public float x, y;
    public Rigidbody rb;

    public float fuerzaDeSalto = 22f;
    public float fuerzaExtra = 0.4f;
    public bool grounded;

    public float velocidadInicial;
    public float velocidadAgachado;

    public bool estoyAtacando;
    public bool avanzoSolo;
    public float impulsoGolpe = 8f;

    public GameObject arma;
    private bool armaActiva = false;

    public float rangoDeteccion = 5f;
    public LayerMask capaEnemigos;
    // Start is called before the first frame update
    void Start()
    {
        grounded = false;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        velocidadInicial = speedMovement;
        velocidadAgachado = speedMovement * 0.5f;

        if (arma != null)
        {
            arma.SetActive(false);
        }

    }
    private void FixedUpdate()
    {
        if (!estoyAtacando)
        {
            transform.Rotate(0, x * Time.deltaTime * speedRotate * 0.5f, 0);
            transform.Translate(0, 0, y * Time.deltaTime * speedMovement);
        }

    }

    void Update()
    {
        y = Input.GetAxis("Vertical");
        x = Input.GetAxis("Horizontal");
        animator.SetFloat("SpeedX", x);
        animator.SetFloat("SpeedY", y);

   
        if (!estoyAtacando)
        {
            if (Input.GetKeyDown(KeyCode.Space) && grounded)  
            {
                Salto();
            }

            
            if (Input.GetKeyDown(KeyCode.F) && !armaActiva && grounded)  
            {
                animator.SetTrigger("Puños");
                AtacarConPuños();
            }

            if (Input.GetMouseButtonDown(0) && grounded && armaActiva)  
            {
                animator.SetTrigger("Arma");
                AtacarConPistola();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                CambiarEstadoArma();
            }

            if (DetectarEnemigo() && !armaActiva && !estoyAtacando)
            {
                AtacarConPuños();
            }
        }

        if (grounded)
        {
            animator.SetBool("Grounded", true);
        }
        else
        {
            Caigo();
        }
    }

    void Salto()
    {
        if (grounded) 
        {
            animator.SetBool("Salto", true); 
            rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);  
            grounded = false; 
        }
    }

    void Caigo()
    {
        animator.SetBool("Grounded", false);
        animator.SetBool("Salto", false);   
    }

    private void AtacarConPuños()
    {
        if (!estoyAtacando)
        {
            estoyAtacando = true;
            Debug.Log("Atacando con puños");
            StartCoroutine(ResetAtaque());
        }
    }

    private void AtacarConPistola()
    {
        if (!estoyAtacando)
        {
            estoyAtacando = true;
            Debug.Log("Disparando con la pistola");
            StartCoroutine(ResetAtaque());
        }
    }

    private IEnumerator ResetAtaque()
    {
        yield return new WaitForSeconds(1f); 
        estoyAtacando = false; 
    }

    private bool DetectarEnemigo()
    {
        Collider[] enemigos = Physics.OverlapSphere(transform.position, rangoDeteccion, capaEnemigos);
        return enemigos.Length > 0;
    }

    private void CambiarEstadoArma()
    {
        armaActiva = !armaActiva;

        if (arma != null)
        {
            arma.SetActive(armaActiva);
        }

        animator.SetBool("ArmaActiva", armaActiva);
    }

}