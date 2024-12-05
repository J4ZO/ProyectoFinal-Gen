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

    public bool hasPistol = false;
    // Start is called before the first frame update
    void Start()
    {
        grounded = false;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        velocidadInicial = speedMovement;
        velocidadAgachado = speedMovement * 0.5f;

        hasPistol = true;
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

        animator.SetBool("HoldPistol",hasPistol);

        if (hasPistol)
        {
            animator.SetLayerWeight(1, 1);
        }

        if (grounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("Salto", true);
                rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);

            }
            animator.SetBool("Grounded", true);
        }
        else
        {
            Caigo();
        }
    }
    void Caigo()
    {
        animator.SetBool("Grounded", false);
        animator.SetBool("Salto", false);   
    }
    
}