using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private InventoryUI inventoryUI;

    private void Start()
    {
        inventoryUI = FindObjectOfType<InventoryUI>();
    }

    private void Update()
    {
        // Detectar si se presiona la tecla "I"
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.ToggleInventory();
        }
    }
}

