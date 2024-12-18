using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuInicial(string nombre)
    {
        SceneManager.LoadScene(nombre); 
    }

    public void Salir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
