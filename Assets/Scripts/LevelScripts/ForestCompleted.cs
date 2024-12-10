using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestCompleted : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private GameObject clue;
    [SerializeField] private GameObject enemyNPC;
    [SerializeField] private GameObject lights;
    [SerializeField] private GameObject wall;
    [SerializeField] private NPCInteraction interaction;
    [SerializeField] private GameObject[] spawns;

    [SerializeField] private AudioClip alertSound;
    private bool hasPlayedSound = false; 

    void Update()
    {
        if (!clue.activeSelf)
        {
            enemyNPC.SetActive(true);
        } 

        if(interaction.isInteractionCompleated)
        {
            if(!hasPlayedSound)
            {
                AudioManager.Instance.PlaySFX(alertSound);
                hasPlayedSound = true; 
            } 
            lights.SetActive(true);
            wall.SetActive(false);
            foreach(GameObject spawn in spawns)
            {
                if(spawn != null)
                {
                    spawn.SetActive(true);
                }
            }
        }
    }

    
}
