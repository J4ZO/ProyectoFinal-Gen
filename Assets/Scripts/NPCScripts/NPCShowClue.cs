using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShowClue : MonoBehaviour
{
    private NPCInteraction interaction;
    [SerializeField] private GameObject textClue;
    [SerializeField] private GameObject footprints;
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
            textClue.SetActive(true);
            try { footprints.SetActive(true); }
            catch (System.Exception e) { }
            
        }
    }


}
