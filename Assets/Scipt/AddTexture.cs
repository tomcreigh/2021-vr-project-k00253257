using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTexture : MonoBehaviour
{
    public GameManager gameManager;

    public Material[] mats;
    public AudioClip[] drums;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            if (gameManager.isGameActive)
            {
                //change material to random colour from array
                GetComponent<Renderer>().material = mats[Random.Range(0, mats.Length)];

                //change audio to random clip from array
                GetComponent<AudioSource>().clip = drums[Random.Range(0, drums.Length)];
                GetComponent<AudioSource>().Play();

                //check game state
                gameManager.CheckPainted(this.gameObject);
            }

            Destroy(other.gameObject);
        }
    }

}
