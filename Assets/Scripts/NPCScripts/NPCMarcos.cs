using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMarcos : MonoBehaviour
{
    private NPCInteraction interaction;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        interaction = GetComponent<NPCInteraction>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(interaction.isInteractionCompleated)
        {
            animator.SetBool("Walking",true);
        }
    }
}
