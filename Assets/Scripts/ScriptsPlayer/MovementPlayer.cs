using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public  float speedMovement = 5.0f;
    [SerializeField] private float speedRotate = 200.0f;
    [SerializeField] private float movX;
    [SerializeField] private float movY,moveRun;

    private Rigidbody rb;
    [SerializeField] private bool grounded;

    [SerializeField] private float fuerzaDeSalto = 22f;

    private Animator animator;
    private bool isRunning;
    [SerializeField] private bool stopMovement;


    private Collectable stopIsPicking;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
        animator = GetComponent<Animator>();  
        stopIsPicking = GameObject.FindGameObjectWithTag("Clue").GetComponent<Collectable>();      
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if(!stopIsPicking.isPicked) 
        {
            Movement();
            if(Input.GetKey(KeyCode.LeftShift))
            {
                Running();
            }else
            {
                //speedMovement = 5f;
                animator.SetBool("Running",false);
                isRunning = false;
            }
        }

        if(stopMovement)
        {
            speedMovement = 0f;
            rb.velocity = Vector3.zero;
        }


        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded) 
            {
                Debug.Log("Salta");
                Salto();
            }
        }
    }




    private void Salto()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); 
        rb.AddForce(Vector3.up * fuerzaDeSalto, ForceMode.Impulse); 
        animator.SetTrigger("Jumping");
        grounded = false; 
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Clue"))
        {
            stopMovement = true;
        }
    }


    public void OnClueDestroyed()
    {
        stopMovement = false;
        speedMovement = 5f;
    }

    private void Movement()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        transform.Rotate(0, movX * Time.deltaTime * speedRotate * 0.5f, 0);
        Vector3 movement = transform.forward * movY * speedMovement;
        rb.AddForce(movement, ForceMode.Impulse);
        if(movY > 0 && !isRunning)
        {
            animator.SetBool("Walking",true);
            animator.SetBool("WalkingBehind",false);
            speedMovement = 5;
        }else
        {
            animator.SetBool("Walking",false);
            animator.SetBool("Running",false);
            animator.SetBool("WalkingBehind",false);
        }

        if(movY < 0)
        {
            animator.SetBool("WalkingBehind",true);
            animator.SetBool("Walking",false);
        }
    }

    private void Running()
    {
        isRunning = true;
        speedMovement = moveRun;
        animator.SetBool("Running",true);
    }

    private void StopMovement()
    {
        // Detiene cualquier movimiento aplicando cero a las velocidades
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Detiene las animaciones de caminar o correr
        animator.SetBool("Walking", false);
        animator.SetBool("Running", false);
        animator.SetBool("WalkingBehind", false);
    }
}
