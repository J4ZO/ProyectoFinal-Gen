using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private GameObject textNPC;
    [SerializeField] private List<GameObject> texts;
    private int indexTexts = 0;
    public bool isPlayerInRange;

    public bool isInteractionCompleated;

    private Animator animator;

    private DialogFragmentController dialog;

    void Start()
    {
        animator = GetComponent<Animator>();
        dialog = GetComponent<DialogFragmentController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("isTalking");
            textNPC.SetActive(true);

            // Avanza el diálogo al siguiente fragmento
            dialog.ShowNextFragment();
        }
        ShowMessages();
    }


    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player") )
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("Player") )
        {
            isPlayerInRange = false;
            textNPC.SetActive(false);
            texts[indexTexts].SetActive(false);
            indexTexts = 0;
            texts[indexTexts].SetActive(true);
        }
    }

    private void ShowMessages()
    {
        if(dialog.IsDialogComplete && isPlayerInRange && textNPC.activeSelf)
        {
            texts[indexTexts].SetActive(false);
            indexTexts++;
            if(indexTexts < texts.Count)
            {
                texts[indexTexts].SetActive(true);
            }
            else
            {
                textNPC.SetActive(false);
                indexTexts = 0;
                texts[indexTexts].SetActive(true);
                isInteractionCompleated = true;
            }
        }

    }
}
