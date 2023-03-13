using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumManager : MonoBehaviour
{
    public GameManager gameManager;

    public AudioClip intro;
    public AudioClip loop;
    public AudioClip outro;
  

    private AudioSource audio;

    // Start is called before the first frame update
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void StartAudio()
    {
        StartCoroutine(PlayAudio(true));
    }

    public void StartOutro()
    {
        StartCoroutine(PlayAudio(false));
    }


    IEnumerator PlayAudio(bool isRunning)
    {
        
        if(isRunning)
        {
            audio.clip = intro;
            audio.Play();
            yield return new WaitForSeconds(audio.clip.length);
            audio.loop = true;
            audio.clip = loop;
            audio.Play();
        }
        else
        {
            //audio.Play();
            //yield return new WaitForSeconds(audio.clip.length);
            audio.clip = outro;
            audio.loop = false;
            audio.Play();
        }

    }
}
