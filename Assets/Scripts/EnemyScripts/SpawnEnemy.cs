using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private bool enemyIsActive;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.activeSelf)
        {
            enemyIsActive = true;
        }
    }
    private void Spawn()
    {
        enemy.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && !enemy.activeSelf && !enemyIsActive)
        {
            enemy.transform.position = transform.position;
            enemy.SetActive(true);
        }    
    }
}
