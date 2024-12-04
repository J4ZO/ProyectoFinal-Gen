using UnityEngine;

public class Collectable : MonoBehaviour
{
    public InventoryItem item; // Asocia un objeto inventariable

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory playerInventory = other.GetComponent<Inventory>();
            if (playerInventory != null)
            {
                playerInventory.AddItem(item);
                Destroy(gameObject); // Elimina el objeto del juego
            }
        }
    }
}

