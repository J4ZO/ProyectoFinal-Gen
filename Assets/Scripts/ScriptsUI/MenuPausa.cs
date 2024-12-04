using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private Slider brilloSlider;  // Slider para el brillo
    [SerializeField] private Slider volumenSlider; // Slider para el volumen
    [SerializeField] private Image filtroBrillo;   // Imagen que simula el brillo
    [SerializeField] private AudioMixer audioMixer; // AudioMixer para el volumen
    private bool juegoPausado = false;

    private void Start()
    {
        // Inicializa los valores de los sliders con los guardados previamente
        brilloSlider.value = PlayerPrefs.GetFloat("brillo", 5f);
        volumenSlider.value = PlayerPrefs.GetFloat("volumen", 0.75f);

        // Aplica los valores iniciales
        CambiarBrillo(brilloSlider.value);
        CambiarVolumen(volumenSlider.value);

        // Vincula los sliders a sus métodos
        brilloSlider.onValueChanged.AddListener(CambiarBrillo);
        volumenSlider.onValueChanged.AddListener(CambiarVolumen);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Jugar();
            }
            else 
            {
                Pausa();
            }
        }
    }
    public void Pausa()
    {
        juegoPausado=true;
        Time.timeScale = 0f ;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Jugar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Restaurar()
    {
        Time.timeScale = 1f; // Asegúrate de restaurar el tiempo a 1 antes de reiniciar.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Salir()
    {
        Time.timeScale = 1f; // Asegúrate de restaurar el tiempo antes de cambiar de escena.
        SceneManager.LoadScene("Menu");
    }

    // Métodos para cambiar brillo y volumen
    public void CambiarBrillo(float valor)
    {
        PlayerPrefs.SetFloat("brillo", valor);
        filtroBrillo.color = new Color(filtroBrillo.color.r, filtroBrillo.color.g, filtroBrillo.color.b, valor);
    }

    public void CambiarVolumen(float valor)
    {
        PlayerPrefs.SetFloat("volumen", valor);
        audioMixer.SetFloat("Volumen", Mathf.Log10(valor) * 20); // Convierte el slider lineal a decibeles
    }
}
