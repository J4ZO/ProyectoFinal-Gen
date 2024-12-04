using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private GameObject textNPC;
    [SerializeField] private List<GameObject> texts;
    private int indexTexts = 0;
    private bool isPlayerInRange = false;

    public bool isInteractionCompleated;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("isTalking");
            textNPC.SetActive(true);
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
        if(Input.GetButtonDown("Fire1") && isPlayerInRange && textNPC.activeSelf)
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
