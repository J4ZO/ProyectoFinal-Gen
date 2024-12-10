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
    [SerializeField] private GameObject panelControles; // Referencia al panel de controles
    [SerializeField] private GameObject infoClue; // Referencia al panel de controles
    [SerializeField] private Slider brilloSlider; // Slider para el brillo
    [SerializeField] private Slider volumenSlider; // Slider para el volumen
    [SerializeField] private Image filtroBrillo; // Imagen que simula el brillo
    [SerializeField] private AudioMixer audioMixer; // AudioMixer para el volumen

    public bool isActive;

    private bool juegoPausado = false;

    private void Start()
    {
        // Inicializa los sliders con los valores guardados
        float brilloGuardado = PlayerPrefs.GetFloat("brillo", 0.5f); // Valor predeterminado
        float volumenGuardado = PlayerPrefs.GetFloat("volumen", 0.75f); // Valor predeterminado

        brilloSlider.value = brilloGuardado;
        volumenSlider.value = volumenGuardado;

        // Aplica los valores iniciales
        CambiarBrillo(brilloGuardado);
        CambiarVolumen(volumenGuardado);

        // Vincula los sliders a sus m�todos
        brilloSlider.onValueChanged.AddListener(CambiarBrillo);
        volumenSlider.onValueChanged.AddListener(CambiarVolumen);
    }

    private void Update()
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

        isActive = infoClue.activeSelf ? true : false;

    }

    public void Pausa()
    {
        isActive= true;
        juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Jugar()
    {
        isActive = false;
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Restaurar()
    {
        Time.timeScale = 1f; // Aseg�rate de restaurar el tiempo antes de reiniciar
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Salir()
    {
        Time.timeScale = 1f; // Aseg�rate de restaurar el tiempo antes de cambiar de escena
        SceneManager.LoadScene("Menu");
    }

    // M�todos para cambiar brillo y volumen
    public void CambiarBrillo(float valor)
    {
        // Invertir el valor del slider (0 ser� m�ximo brillo, 1 ser� m�nimo brillo)
        float brilloInvertido = 1f - valor;
        PlayerPrefs.SetFloat("brillo", brilloInvertido);

        // Actualizar el filtro de brillo
        filtroBrillo.color = new Color(filtroBrillo.color.r, filtroBrillo.color.g, filtroBrillo.color.b, brilloInvertido);
    }

    public void CambiarVolumen(float valor)
    {
        PlayerPrefs.SetFloat("volumen", valor);

        // Ajustar el volumen en el AudioMixer (convertir a decibeles)
        audioMixer.SetFloat("Volumen", Mathf.Log10(valor) * 20);
    }

    // M�todo para ir al panel de controles
    public void MostrarControles()
    {
        menuPausa.SetActive(false); // Desactiva el men� de pausa
        panelControles.SetActive(true); // Activa el panel de controles
    }

    // M�todo para volver al men� de pausa desde el panel de controles
    public void VolverMenuPausa()
    {
        panelControles.SetActive(false); // Desactiva el panel de controles
        menuPausa.SetActive(true); // Activa el men� de pausa
    }
}

