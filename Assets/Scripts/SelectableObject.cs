using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    public Material defaultMaterial;

    private void Awake()
    {
        defaultMaterial = GetComponent<Renderer>().material;
    }
}
