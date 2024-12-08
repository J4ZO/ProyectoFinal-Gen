using UnityEngine;
using TMPro;

public class ItemDescriptionUI : MonoBehaviour
{
    public GameObject descriptionPanel; // El panel que contiene el texto
    public TextMeshProUGUI descriptionText; // Texto para la descripci�n

    private void Start()
    {
        descriptionPanel.SetActive(false); // Aseg�rate de que el panel est� oculto al inicio
    }

    // M�todo para mostrar la descripci�n
    public void ShowDescription(string description)
    {
        descriptionText.text = description;
        descriptionPanel.SetActive(true);
    }

    // M�todo para ocultar la descripci�n
    public void HideDescription()
    {
        descriptionPanel.SetActive(false);
    }

    private void Update()
    {
        // Opci�n para ocultar el panel presionando una tecla, como "Esc"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideDescription();
        }
    }
}
