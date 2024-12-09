using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void Spawn()
    {
        enemy.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && !enemy.activeSelf)
        {
            enemy.transform.position = transform.position;
            enemy.SetActive(true);
        }    
    }
}
