using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float speedMovement = 5.0f;
    [SerializeField] private float speedRotate = 200.0f;
    [SerializeField] private float movX;
    [SerializeField] private float movY;

    private Rigidbody rb;
    [SerializeField] private bool grounded;

    [SerializeField] private float fuerzaDeSalto = 22f;

    private Animator animator;
    private bool isRunning;

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
                speedMovement = 5f;
                animator.SetBool("Running",false);
                isRunning = false;
            }
        }
    }



    // void Salto()
    // {
    //     if (grounded) 
    //     {
    //         rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);  
    //         grounded = false; 
    //     }
    // }

    // private void OnCollisionEnter(Collision other) {
    //     if(other.gameObject.CompareTag("Ground"))
    //     {
    //         grounded = true;
    //     }
    // }

    private void Movement()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        transform.Rotate(0, movX * Time.deltaTime * speedRotate * 0.5f, 0);
        transform.Translate(0, 0, movY * Time.deltaTime * speedMovement);
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
        speedMovement = 10f;
        animator.SetBool("Running",true);
    }
}
