using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField]  GameObject textNPC;
    [SerializeField]  List<GameObject> texts;
    private int indexTexts = 0;
    private bool isPlayerInRange = false;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pulso E");
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
            }
        }

    }
}
