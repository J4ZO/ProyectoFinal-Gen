using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Controller2 : MonoBehaviour
{
    [SerializeField] private Level3Controller isCompleated;
    [SerializeField] private GameObject eterClue;
    [SerializeField] private GameObject marcosEnemy;
    [SerializeField] private GameObject lighsMarco;
    [SerializeField] private AudioClip alertSound;
    [SerializeField] private bool clueAppeared;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(clueAppeared && !eterClue.activeSelf)
        {
            StartCoroutine(WaitToSpawnMarcos());
        }

    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            if(isCompleated.stateCompleated)
            {
                AudioManager.Instance.PlaySFX(alertSound);
                eterClue.SetActive(true);
                clueAppeared = true;
            }
        }
    }

    private IEnumerator WaitToSpawnMarcos()
    {
        lighsMarco.SetActive(true);
        yield return new WaitForSeconds(5f);
        marcosEnemy.SetActive(true);
    }
}
