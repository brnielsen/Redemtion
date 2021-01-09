using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    public static MusicManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeSong(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

}
