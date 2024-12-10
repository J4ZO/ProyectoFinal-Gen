using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Asegúrate de incluir esto si no lo has hecho

public class Collectable : MonoBehaviour
{
    public InventoryItem item; // Asocia un objeto inventariable
    private Animator animator;

    public bool isPicked;
    private bool isPlayerInRange;
    private MovementPlayer player;

    [SerializeField] private GameObject textCanvas; // Canvas informativo
    [SerializeField] private GameObject text;
    [SerializeField] private TextMeshProUGUI textMessage; // Aquí cambiamos a TextMeshProUGUI
    [SerializeField] private string message = "Presiona E para recolectar\nPresiona I para mostrar inventario"; // Mensaje informativo

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementPlayer>();

        // Asegurarse de que el canvas esté desactivado al inicio
        if (textCanvas != null)
        {
            textCanvas.SetActive(false);
        }
    }

    private void Update()
    {
        // Verifica si el jugador está cerca y presiona E
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !isPicked)
        {
            isPicked = true;
            Debug.Log("Recoge objeto");

            // Desactivar el canvas informativo cuando el jugador presiona E
            if (textCanvas != null)
            {
                textCanvas.SetActive(false);
            }

            StartCoroutine(PickItem());
            text.SetActive(true);
        }

        // Opcional: Mostrar inventario al presionar I
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Mostrar inventario");
            // Lógica para mostrar el inventario
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator = other.GetComponent<Animator>();
            isPlayerInRange = true;

            // Mostrar el canvas con el mensaje
            if (textCanvas != null)
            {
                textCanvas.SetActive(true);
                if (textMessage != null)
                {
                    textMessage.text = message; // Configurar el mensaje
                }
            }

            Debug.Log("Jugador en rango");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;

            // Ocultar el canvas
            if (textCanvas != null)
            {
                textCanvas.SetActive(false);
            }

            Debug.Log("El jugador salió de rango");
        }
    }

    private void OnDestroy()
    {
        
    }

    private IEnumerator PickItem()
    {
        if (animator != null)
        {
            animator.SetTrigger("Pick");
        }

        yield return new WaitForSeconds(3f);

        // Agregar el objeto al inventario
        Inventory playerInventory = FindObjectOfType<Inventory>();
        if (playerInventory != null)
        {
            playerInventory.AddItem(item);
        }

        // Mostrar descripción del objeto si tiene
        ItemDescriptionUI descriptionUI = FindObjectOfType<ItemDescriptionUI>();
        if (descriptionUI != null && !string.IsNullOrEmpty(item.description))
        {
            descriptionUI.ShowDescription(item.description);
        }

        gameObject.SetActive(false);
        isPicked = false;
        if (player != null)
        {
            player.OnClueDestroyed();
        }
    }
}
