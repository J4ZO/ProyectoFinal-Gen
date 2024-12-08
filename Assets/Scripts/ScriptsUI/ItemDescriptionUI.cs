using UnityEngine;
using TMPro;

public class ItemDescriptionUI : MonoBehaviour
{
    public GameObject descriptionPanel; // El panel que contiene el texto
    public TextMeshProUGUI descriptionText; // Texto para la descripción

    private void Start()
    {
        descriptionPanel.SetActive(false); // Asegúrate de que el panel esté oculto al inicio
    }

    // Método para mostrar la descripción
    public void ShowDescription(string description)
    {
        descriptionText.text = description;
        descriptionPanel.SetActive(true);
    }

    // Método para ocultar la descripción
    public void HideDescription()
    {
        descriptionPanel.SetActive(false);
    }

    private void Update()
    {
        // Opción para ocultar el panel presionando una tecla, como "E"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideDescription();
        }
    }
}
