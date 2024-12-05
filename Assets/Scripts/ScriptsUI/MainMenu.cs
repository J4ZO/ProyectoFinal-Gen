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
    public GameObject panelPlayControles; // Panel de controles desde el botón Jugar

    // Referencia al AudioMixer
    [SerializeField] private AudioMixer audioMixer;
    public Slider slider;
    public float sliderValue;
    public Image filtroBrillo; // Imagen que simula el brillo

    private void Start()
    {
        // Configurar brillo inicial
        if (!PlayerPrefs.HasKey("brillo"))
        {
            PlayerPrefs.SetFloat("brillo", 0.5f); // Valor estándar
            PlayerPrefs.Save();
        }

        // Leer el valor de brillo guardado o el estándar
        sliderValue = PlayerPrefs.GetFloat("brillo", 0.5f);
        filtroBrillo.color = new Color(filtroBrillo.color.r, filtroBrillo.color.g, filtroBrillo.color.b, sliderValue);

        // Configurar el slider para reflejar el valor inicial
        if (slider != null)
            slider.value = sliderValue;

        // Mostrar el menú principal al iniciar
        ShowMenuPrincipal();
    }

    // Métodos para mostrar los diferentes menús
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

    // Método para mostrar el panel de controles desde el botón Jugar
    public void ShowPanelPlayControles()
    {
        menuPrincipal.SetActive(false);
        panelPlayControles.SetActive(true); // Mostrar el panel de controles desde Jugar
    }

    // Métodos para cerrar paneles y volver al menú principal
    public void VolverAlMenuPrincipal()
    {
        ShowMenuPrincipal();
    }

    // Método para cargar la siguiente escena desde el panel Play
    public void Jugar()
    {
        // Cargar la escena de la historia (asumimos que se llama "Historia")
        SceneManager.LoadScene(1);
    }

    // Método para cambiar el volumen
    public void CambiarVolumen(float volumen)
    {
        audioMixer.SetFloat("Volumen", volumen);
    }

    // Método para cambiar el brillo
    public void CambiarBrillo(float valor)
    {
        // Guardar el valor en PlayerPrefs
        sliderValue = valor;
        PlayerPrefs.SetFloat("brillo", sliderValue);
        PlayerPrefs.Save();

        // Actualizar el filtro de brillo
        filtroBrillo.color = new Color(
            filtroBrillo.color.r,
            filtroBrillo.color.g,
            filtroBrillo.color.b,
            sliderValue
        );
    }

    public void Salir()
    {
        Debug.Log("Saliendo");
        Application.Quit();
    }
}

