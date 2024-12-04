using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    // Referencias a los paneles
    public GameObject menuPrincipal;
    public GameObject menuOpciones;
    public GameObject menuCreditos;
    public GameObject menuControles; // Nuevo panel de controles
    public GameObject panelPlayControles; // Panel de controles desde el bot�n Jugar

    // Referencia al AudioMixer
    [SerializeField] private AudioMixer audioMixer;
    public Slider slider;
    public float sliderValue;
    public Image filtroBrillo; // Imagen que simula el brillo

    private void Start()
    {
        // Configurar brillo inicial
        slider.value = PlayerPrefs.GetFloat("brillo", 5f);
        filtroBrillo.color = new Color(filtroBrillo.color.r, filtroBrillo.color.g, filtroBrillo.color.b, slider.value);

        // Mostrar el men� principal al iniciar
        ShowMenuPrincipal();
    }

    // M�todos para mostrar los diferentes men�s
    public void ShowMenuPrincipal()
    {
        menuPrincipal.SetActive(true);
        menuOpciones.SetActive(false);
        menuCreditos.SetActive(false);
        menuControles.SetActive(false);
        panelPlayControles.SetActive(false);
    }

    public void ShowMenuOpciones()
    {
        menuPrincipal.SetActive(false);
        menuOpciones.SetActive(true);
    }

    public void ShowMenuCreditos()
    {
        menuPrincipal.SetActive(false);
        menuCreditos.SetActive(true);
    }

    public void ShowMenuControles()
    {
        menuPrincipal.SetActive(false);
        menuControles.SetActive(true);
    }

    // M�todo para mostrar el panel de controles desde el bot�n Jugar
    public void ShowPanelPlayControles()
    {
        menuPrincipal.SetActive(false);
        panelPlayControles.SetActive(true); // Mostrar el panel de controles desde Jugar
    }

    // M�todos para cerrar paneles y volver al men� principal
    public void VolverAlMenuPrincipal()
    {
        ShowMenuPrincipal();
    }

    // M�todo para cargar la siguiente escena desde el panel Play
    public void Jugar()
    {
        // Cargar la escena de la historia (asumimos que se llama "Historia")
        SceneManager.LoadScene(1);
    }

    // M�todo para cambiar el volumen
    public void CambiarVolumen(float volumen)
    {
        audioMixer.SetFloat("Volumen", volumen);
    }

    public void CambiarBrillo(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("brillo", sliderValue);
        filtroBrillo.color = new Color(filtroBrillo.color.r, filtroBrillo.color.g, filtroBrillo.color.b, slider.value);
    }

    public void Salir()
    {
        Debug.Log("Saliendo");
        Application.Quit();
    }
}
