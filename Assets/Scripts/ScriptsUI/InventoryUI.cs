using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel; // Panel del inventario
    public Transform itemsParent; // Contenedor de ítems
    public GameObject inventorySlotPrefab; // Prefab de cada slot

    private Inventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        inventoryPanel.SetActive(false); // El inventario está oculto al inicio
        UpdateUI();
    }

    public void UpdateUI()
    {
        foreach (Transform child in itemsParent)
        {
            Destroy(child.gameObject);
        }

        foreach (InventoryItem item in inventory.items)
        {
            GameObject slot = Instantiate(inventorySlotPrefab, itemsParent);
            slot.transform.GetChild(0).GetComponent<Image>().sprite = item.icon;

        }

    }

    // Método para alternar la visibilidad del inventario
    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }
}
