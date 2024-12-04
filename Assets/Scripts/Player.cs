using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float horizontal;
    public float vertical;
    public float giroVelociadad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vertical);
        
        horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * giroVelociadad * Time.deltaTime * horizontal);
        
    }
}
