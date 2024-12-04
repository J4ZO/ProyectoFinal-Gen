using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();

    public void AddItem(InventoryItem item)
    {
        if (!items.Contains(item))
        {
            items.Add(item);
            Debug.Log($"Agregado al inventario: {item.itemName}");

            // Notificar a InventoryUI para que actualice la interfaz
            InventoryUI inventoryUI = FindObjectOfType<InventoryUI>();
            if (inventoryUI != null)
            {
                inventoryUI.UpdateUI();
            }
        }
        else
        {
            Debug.Log($"{item.itemName} ya está en el inventario.");
        }
    }

}

