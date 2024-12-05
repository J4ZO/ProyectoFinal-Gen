using System.Collections;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public InventoryItem item; // Asocia un objeto inventariable
    private Animator animator;
    
    public bool isPicked;
    private bool isPlayerInRange;

    private void Update()
    {
        // Verifica si el jugador está cerca y presiona E
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !isPicked)
        {
            isPicked = true;
            Debug.Log("Recoge objeto");
            StartCoroutine(PickItem());
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator = other.GetComponent<Animator>();
            isPlayerInRange = true;
            Debug.Log("player in range"); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador salió de rango");
            isPlayerInRange = false;
        }
    }

    private IEnumerator PickItem()
    {
        if (animator != null)
        {
            animator.SetTrigger("Pick");
        }

        yield return new WaitForSeconds(3f); 

        
        Inventory playerInventory = FindObjectOfType<Inventory>();
        if (playerInventory != null)
        {
            playerInventory.AddItem(item);
        }

        Destroy(gameObject);
        isPicked = false; 
    }
}

