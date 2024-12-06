using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    [SerializeField] private NPCInteraction interactionNPC;
    [SerializeField] private float timeMax = 15f;
    private float currentTime;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!enemy.activeSelf && (interactionNPC.isInteractionCompleated || interactionNPC.isPlayerInRange))
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
        enemy.transform.position = transform.position;
    }
}
