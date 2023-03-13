using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public DrumManager drumManager;
    public SpawnManager spawnManager;

    public GameObject titleScreen;
    public Button startButton;
    public GameObject endScreen;
    public Button menuButton;

    public GameObject[] paintableArray;
    public List<GameObject> paintable;
    public List<GameObject> painted;
    public Material white;

    public bool isGameActive;


    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
        drumManager.StartAudio();
        isGameActive = true;
        spawnManager.Run();
        
        //clear lists to avoid duplication
        paintable.Clear();
        painted.Clear();

        //populate list paintable
        paintableArray = GameObject.FindGameObjectsWithTag("paintable");
        foreach (GameObject g in paintableArray)
        {
            g.GetComponent<Renderer>().material = white;
            paintable.Add(g);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void CheckPainted(GameObject g)
    {
        int index = paintable.IndexOf(g);
        //Debug.Log(index);

        if (paintable[index] != null)
        {
            painted.Add(paintable[index]);
            paintable[index] = null;
        }

        if (painted.Count >= paintable.Count)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        //spawnManager.Run();
        drumManager.StartOutro();
        //ActivateEndScreen();
        StartCoroutine(ShowEndScreen());
    }

    public void ActivateEndScreen()
    {
        endScreen.gameObject.SetActive(true);

    }

    IEnumerator ShowEndScreen()
    {
        yield return new WaitForSeconds(1.5f);
        ActivateEndScreen();
    }
}
