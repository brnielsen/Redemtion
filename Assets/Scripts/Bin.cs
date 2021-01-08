using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{

    public ReturnableType returnableTypeAccepted;

    private void OnTriggerEnter(Collider other)
    {
        SelectableObject selectableObject = other.GetComponent<SelectableObject>();
        if(selectableObject.returnableType == returnableTypeAccepted)
        {
            Debug.Log("Yay points!");
        }
        else
        {
            Debug.Log("Don't put that in my mouth!");
        }

    }
}
