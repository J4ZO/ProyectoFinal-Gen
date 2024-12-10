using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShowClue : MonoBehaviour
{
    private NPCInteraction interaction;
    [SerializeField] private GameObject textClue;
    [SerializeField] private GameObject objectToShow;
    private bool hasPlayedSound = false; 
    [SerializeField] private AudioClip alertSound;

    // Start is called before the first frame update
    void Start()
    {
        interaction = GetComponent<NPCInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        if(interaction.isInteractionCompleated)
        {
            if(!hasPlayedSound)
            {
                AudioManager.Instance.PlaySFX(alertSound);
                hasPlayedSound = true; 
            } 
            textClue.SetActive(true);
            try { objectToShow.SetActive(true); }
            catch (System.Exception) { }
            
        }
    }


}
