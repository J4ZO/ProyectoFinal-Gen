using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private GameObject textNPC; // Texto del diálogo del NPC
    [SerializeField] private List<GameObject> texts; // Lista de mensajes de diálogo
    [SerializeField] private GameObject interactionCanvas; // Canvas que muestra la tecla de interacción

    private int indexTexts = 0;
    public bool isPlayerInRange;

    public bool isInteractionCompleated;

    private Animator animator;

    private DialogFragmentController dialog;

    void Start()
    {
        animator = GetComponent<Animator>();
        dialog = GetComponent<DialogFragmentController>();

        if (interactionCanvas != null)
        {
            interactionCanvas.SetActive(false); // Asegúrate de que el canvas esté apagado al inicio
        }
    }

    void Update()
    {
        if (isPlayerInRange)
        {
            if (interactionCanvas != null && !interactionCanvas.activeSelf)
            {
                interactionCanvas.SetActive(true); // Muestra el canvas cuando el jugador está cerca
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetTrigger("isTalking");
                textNPC.SetActive(true);

                // Avanza el diálogo al siguiente fragmento
                dialog.ShowNextFragment();
            }
        }
        else if (interactionCanvas != null && interactionCanvas.activeSelf)
        {
            interactionCanvas.SetActive(false); // Oculta el canvas cuando el jugador se aleja
        }

        ShowMessages();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
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
        if (dialog.IsDialogComplete && isPlayerInRange && textNPC.activeSelf)
        {
            texts[indexTexts].SetActive(false);
            indexTexts++;
            if (indexTexts < texts.Count)
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

