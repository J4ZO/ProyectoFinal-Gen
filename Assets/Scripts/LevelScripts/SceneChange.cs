using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private NPCInteraction interaction;
    [SerializeField] private int numberScene;
    [SerializeField] private GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Player") && interaction.isInteractionCompleated)
        {
            SceneManager.LoadScene(numberScene);
        }else
        {
            canvas.SetActive(true);
            StartCoroutine(WaitCanvas());
        }
        
    }

    private IEnumerator WaitCanvas()
    {
        yield return new WaitForSeconds(10f);
        canvas.SetActive(false);
    }
}
