using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{

    public ReturnableType returnableTypeAccepted;

    private Score score;
    public AudioClip successSound;
    public AudioClip failSound;

    AudioSource audioSource;


    private void Awake()
    {
        score = FindObjectOfType<Score>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        SelectableObject selectableObject = other.GetComponent<SelectableObject>();
        if(selectableObject.returnableType == returnableTypeAccepted)
        {
            score.currentScore += 1;
            Score.updateScore.Invoke();

            audioSource.PlayOneShot(successSound);
        }
        else
        {
            audioSource.PlayOneShot(failSound);


        }

    }
}
