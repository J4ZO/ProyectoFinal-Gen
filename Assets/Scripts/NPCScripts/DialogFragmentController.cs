using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogFragmentController : MonoBehaviour
{
    public TMP_Text dialogText; // Asigna el componente de texto del Canvas aqu�
    [TextArea(3, 10)] public string fullDialog; // El texto completo a mostrar
    public float fragmentDisplayTime = 3f; // Tiempo entre fragmentos
    public int maxCharactersPerFragment = 80; // M�ximo n�mero de caracteres por fragmento

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
        if (fragmentCoroutine == null) // Evita que se duplique la ejecuci�n
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

        // Cuando termina el di�logo, limpia el texto (opcional)
        dialogText.text = "";
        fragmentCoroutine = null;
        currentFragmentIndex = 0; // Reinicia para poder reutilizar
    }

    private string[] SplitTextIntoFragments(string text, int maxCharacters)
    {
        List<string> fragmentList = new List<string>();
        int index = 0;

        while (index < text.Length)
        {
            int length = Mathf.Min(maxCharacters, text.Length - index);
            fragmentList.Add(text.Substring(index, length));
            index += length;
        }

        return fragmentList.ToArray();
    }
}

