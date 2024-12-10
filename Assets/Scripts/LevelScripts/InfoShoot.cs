using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoShoot : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
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
