using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    [SerializeField] private float timeMax = 15f;
    private float currentTime;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!enemy.activeSelf)
        {
            currentTime += Time.deltaTime;
            Debug.Log(currentTime);
            if(currentTime >= timeMax)
            {
                Spawn();
                enemy.SetActive(true);
                currentTime = 0f;
                Debug.Log("Aparece enemigo");
            }
        }
    
    }
    private void Spawn()
    {
        Vector3 playerPosition = player.transform.position;
        enemy.transform.position = playerPosition + new Vector3(10f,0f,0f);
    }
}
