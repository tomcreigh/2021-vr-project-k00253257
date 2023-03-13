using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameManager gameManager; 

    public GameObject[] notes;

    private float startDelay = .9f;
    private float repeatDelay = 1.2f;



    public void Run()
    {
        if (gameManager.isGameActive)
        {
            //InvokeRepeating("SpawnPrefab", startDelay, repeatDelay);
            StartCoroutine(SpawnDelay());
        }
    }

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(startDelay);
        StartCoroutine(SpawnPrefab());
    }
    IEnumerator SpawnPrefab()
    {
        while (gameManager.isGameActive)
        {
            yield return new WaitForSeconds(repeatDelay);
            int randomIndex = Random.Range(0, notes.Length);
            Instantiate(notes[randomIndex], new Vector3(-9, 2.7f, 0), Quaternion.Euler(new Vector3(Random.Range(-70, -110), Random.Range(-170, -190), 0)));
        }
    }

    //void SpawnPrefab()
    //{
    //    int randomIndex = Random.Range(0, notes.Length);
    //    Instantiate(notes[randomIndex], new Vector3(-9, 2.7f, 0), Quaternion.Euler(new Vector3(Random.Range(-70, -110), Random.Range(-170, -190), 0)));
    //}

}
