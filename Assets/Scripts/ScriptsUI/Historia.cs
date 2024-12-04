using System.Collections;
using UnityEngine;
using TMPro;

public class Historia : MonoBehaviour
{
    public TextMeshProUGUI textoHistoria; // TextMeshPro para mostrar la historia
    public string historiaCompleta; // Texto completo de la historia
    public float velocidadEscritura = 0.1f; // Tiempo entre letras
    public AudioSource sonidoMaquina; // Sonido de m�quina de escribir
    public AudioSource sonidoFondo; // Sonido de fondo

    private void Start()
    {
        if (sonidoFondo != null)
        {
            sonidoFondo.Play(); // Iniciar el sonido de fondo
        }

        StartCoroutine(MostrarHistoria());
    }

    IEnumerator MostrarHistoria()
    {
        textoHistoria.text = ""; // Inicializar texto vac�o

        foreach (char letra in historiaCompleta.ToCharArray())
        {
            textoHistoria.text += letra; // Agregar una letra al texto

            // Reproducir sonido si no es un espacio
            if (letra != ' ' && sonidoMaquina != null)
            {
                sonidoMaquina.Play();
            }

            // Pausar m�s tiempo al final de una frase o pregunta
            if (letra == '.' || letra == '!' || letra == '?')
            {
                yield return new WaitForSeconds(0.5f); // Pausa larga
            }
            else
            {
                yield return new WaitForSeconds(velocidadEscritura); // Pausa normal entre letras
            }
        }

        yield return new WaitForSeconds(2); // Esperar antes de continuar

        if (sonidoFondo != null)
        {
            sonidoFondo.Stop(); // Detener el sonido de fondo antes de cargar el juego
        }

        CargarJuego(); // Transici�n al juego
    }

    void CargarJuego()
    {
        // Cambia "Level1" por el nombre de la escena de tu juego
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
