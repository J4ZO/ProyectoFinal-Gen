using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogFragmentController : MonoBehaviour
{
    public TMP_Text dialogText; // Asigna el componente de texto del Canvas aquí
    [TextArea(3, 10)] public string fullDialog; // El texto completo a mostrar
    public float fragmentDisplayTime = 3f; // Tiempo entre fragmentos
    public int maxCharactersPerFragment = 80; // Máximo número de caracteres por fragmento

    private string[] fragments; // Fragmentos del texto
    private int currentFragmentIndex = 0;
    private Coroutine fragmentCoroutine;

    void Start()
    {
        // Divide el texto completo en fragmentos
        fragments = SplitTextIntoFragments(fullDialog, maxCharactersPerFragment);
    }

    public void StartFragmentedDialog()
    {
        if (fragmentCoroutine == null) // Evita que se duplique la ejecución
        {
            fragmentCoroutine = StartCoroutine(ShowDialogByFragments());
        }
    }

    private IEnumerator ShowDialogByFragments()
    {
        while (currentFragmentIndex < fragments.Length)
        {
            dialogText.text = fragments[currentFragmentIndex];
            currentFragmentIndex++;
            yield return new WaitForSeconds(fragmentDisplayTime);
        }

        // Cuando termina el diálogo, limpia el texto (opcional)
        dialogText.text = "";
        fragmentCoroutine = null;
        currentFragmentIndex = 0; // Reinicia para poder reutilizar
    }

    private string[] SplitTextIntoFragments(string text, int maxCharacters)
    {
        List<string> fragmentList = new List<string>();
        string[] words = text.Split(' '); // Divide el texto en palabras
        string currentFragment = "";

        foreach (string word in words)
        {
            // Si agregar la palabra excede el límite, guarda el fragmento actual y comienza uno nuevo
            if ((currentFragment + word).Length > maxCharacters)
            {
                fragmentList.Add(currentFragment.Trim());
                currentFragment = "";
            }

            currentFragment += word + " ";
        }

        // Agrega el último fragmento si no está vacío
        if (!string.IsNullOrEmpty(currentFragment))
        {
            fragmentList.Add(currentFragment.Trim());
        }

        return fragmentList.ToArray();
    }

}

