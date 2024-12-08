using System.Collections;
using UnityEngine;
using TMPro;

public class Historia : MonoBehaviour
{
    public TextMeshProUGUI textoHistoria; // TextMeshPro para mostrar la historia
    public string historiaCompleta; // Texto completo de la historia
    public float velocidadEscritura = 0.1f; // Tiempo entre letras
    public AudioSource sonidoMaquina; // Sonido de máquina de escribir
    public AudioSource sonidoFondo; // Sonido de fondo
    public string escenaSiguiente = "Level1_final"; // Nombre de la escena siguiente

    private Coroutine historiaCoroutine;
    private bool historiaMostrada = false; // Control para saber si la historia ya está completamente mostrada

    private void Start()
    {
        if (sonidoFondo != null)
        {
            sonidoFondo.Play(); // Iniciar el sonido de fondo
        }

        historiaCoroutine = StartCoroutine(MostrarHistoria());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SaltarHistoria();
        }
    }

    IEnumerator MostrarHistoria()
    {
        textoHistoria.text = ""; // Inicializar texto vacío
        historiaMostrada = false;

        foreach (char letra in historiaCompleta.ToCharArray())
        {
            textoHistoria.text += letra; // Agregar una letra al texto

            // Reproducir sonido si no es un espacio
            if (letra != ' ' && sonidoMaquina != null)
            {
                sonidoMaquina.Play();
            }

            // Pausar más tiempo al final de una frase o pregunta
            if (letra == '.' || letra == '!' || letra == '?')
            {
                yield return new WaitForSeconds(0.5f); // Pausa larga
            }
            else
            {
                yield return new WaitForSeconds(velocidadEscritura); // Pausa normal entre letras
            }
        }

        historiaMostrada = true; // Indicar que el texto ya está completamente mostrado
        yield return new WaitForSeconds(2); // Esperar antes de continuar

        if (sonidoFondo != null)
        {
            sonidoFondo.Stop(); // Detener el sonido de fondo antes de cargar el juego
        }

        CargarJuego(); // Transición al juego
    }

    void SaltarHistoria()
    {
        if (!historiaMostrada)
        {
            // Detener la animación de la historia
            if (historiaCoroutine != null)
            {
                StopCoroutine(historiaCoroutine);
            }

            textoHistoria.text = historiaCompleta; // Mostrar texto completo
            historiaMostrada = true; // Marcar la historia como mostrada

            if (sonidoMaquina != null)
            {
                sonidoMaquina.Stop(); // Detener el sonido de máquina
            }
        }
        else
        {
            // Si la historia ya estaba mostrada, cargar el juego inmediatamente
            CargarJuego();
        }
    }

    void CargarJuego()
    {
        if (sonidoFondo != null)
        {
            sonidoFondo.Stop(); // Asegurar que el sonido de fondo se detiene
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1_final");
    }
}
