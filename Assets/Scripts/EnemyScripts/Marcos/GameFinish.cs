using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{
    private EnemyController enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth.GetDie())
        {
            StartCoroutine(FinishGame());
        }
    }


    private IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(5);
    }
}
