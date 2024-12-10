using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Controller : MonoBehaviour
{
    [SerializeField] private GameObject marcosNPC;
    [SerializeField] private GameObject marcosNPCPos2;
    [SerializeField] private GameObject targetPointMarcos2;
    [SerializeField] private GameObject spawnEnemies;
    [SerializeField] private NPCInteraction interaction;
    [SerializeField] private NPCInteraction interaction2;
    [SerializeField] private GameObject receiptClue;
    public bool stateCompleated;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(interaction.isInteractionCompleated && !receiptClue.activeSelf)
        {
            marcosNPCPos2.SetActive(true);
            interaction.isInteractionCompleated = false;
        }

        if(interaction2.isInteractionCompleated)
        {
            marcosNPCPos2.transform.position = Vector3.MoveTowards(marcosNPCPos2.transform.position, targetPointMarcos2.transform.position, 10f * Time.deltaTime);
            if (marcosNPCPos2.transform.position == targetPointMarcos2.transform.position)
            {
                marcosNPCPos2.SetActive(false);
                stateCompleated = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            if(!interaction.isInteractionCompleated)
            {
                marcosNPC.SetActive(true);
            }

            if(interaction.isInteractionCompleated)
            {
                marcosNPC.SetActive(false);
            }

            if(receiptClue.activeSelf)
            {
                spawnEnemies.SetActive(true);
            }
        }

    }
}
