using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ObjectSpawner objectSpawner;
    // Start is called before the first frame update
    void Awake()
    {
        objectSpawner = FindObjectOfType<ObjectSpawner>();

        objectSpawner.SpawnObjects();
    }


}
