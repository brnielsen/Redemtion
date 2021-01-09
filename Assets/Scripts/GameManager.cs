using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ObjectSpawner objectSpawner;
    // Start is called before the first frame update
    Countdown countdownTimer;
    PlayerController player;

    public AudioClip levelMusic;
    MusicManager musicManager;

    bool endOfLevel = false;
    void Awake()
    {
        objectSpawner = FindObjectOfType<ObjectSpawner>();
        objectSpawner.SpawnObjects();

        countdownTimer = FindObjectOfType<Countdown>();
        player = FindObjectOfType<PlayerController>();

        musicManager = FindObjectOfType<MusicManager>();
        if(musicManager != null)
        {
            musicManager.ChangeSong(levelMusic);
        }

    }

    public bool EndLevel()
    {
        player.enabled = false;
        return endOfLevel = true;

    }


}
