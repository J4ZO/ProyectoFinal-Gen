using UnityEngine;

public class SuspectsPanelController : MonoBehaviour
{
    public GameObject suspectsPanel; // Asigna aquí el panel de sospechosos en el inspector.

    void Update()
    {
        // Detecta si el jugador presiona "G"
        if (Input.GetKeyDown(KeyCode.G))
        {
            // Alternar el estado del panel
            bool isActive = suspectsPanel.activeSelf;
            suspectsPanel.SetActive(!isActive);
        }
    }
}


