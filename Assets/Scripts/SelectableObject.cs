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

}

public enum ReturnableType { medCan, smallCan, beerBottle, wineBottle, plasticBottle, plasticLiter }
