using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{

    public ReturnableType returnableTypeAccepted;

    private Score score;


    private void Awake()
    {
        score = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        SelectableObject selectableObject = other.GetComponent<SelectableObject>();
        if(selectableObject.returnableType == returnableTypeAccepted)
        {
            score.currentScore += 1;
            Score.updateScore.Invoke();
            //Play afirmative sound
        }
        else
        {
            //Play negative sound

        }

    }
}
