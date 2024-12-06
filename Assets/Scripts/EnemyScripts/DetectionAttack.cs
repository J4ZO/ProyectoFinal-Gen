using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionAttack : MonoBehaviour
{
    private HealthController healthPlayer;
    // Start is called before the first frame update
    void Start()
    {
        healthPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            healthPlayer.DamagePlayer(5f);
        }
    }
}
