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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        transform.Rotate(0, movX * Time.deltaTime * speedRotate * 0.5f, 0);
        transform.Translate(0, 0, movY * Time.deltaTime * speedMovement);


        if (Input.GetKeyDown(KeyCode.Space) && grounded)  
        {
            Salto();
        }
    }

    void Salto()
    {
        if (grounded) 
        {
            rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);  
            grounded = false; 
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
