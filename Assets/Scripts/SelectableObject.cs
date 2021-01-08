using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    public Material defaultMaterial;

    public ReturnableType returnableType;


    private void Awake()
    {
        defaultMaterial = GetComponent<Renderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            Debug.Log("Why you makin mess?");
            //Play sound based on type
        }
    }

}

public enum ReturnableType { medCan, smallCan, beerBottle, wineBottle, plasticBottle, plasticLiter }
