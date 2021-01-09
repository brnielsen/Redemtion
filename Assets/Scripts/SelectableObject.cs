using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    public Material defaultMaterial;

    public ReturnableType returnableType;

    public AudioClip hitFloor;
    public AudioClip hitBin;
    private AudioSource audioSource;



    private void Awake()
    {
        defaultMaterial = GetComponent<Renderer>().material;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            audioSource.PlayOneShot(hitFloor);


        }

        if (other.gameObject.CompareTag("Bin"))
        {
            audioSource.PlayOneShot(hitBin);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bin"))
        {
            audioSource.PlayOneShot(hitBin);

        }
    }


}

public enum ReturnableType { medCan, smallCan, beerBottle, wineBottle, plasticBottle, plasticLiter }
