using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectListPrefab;

    public Transform spawnLocation;
    public void SpawnObjects()
    {
        List<GameObject> objectList = objectListPrefab.GetComponent<ObjectListHolder>().objectList;

        for (int i = 0; i < objectList.Count; i++)
        {
            Instantiate(objectList[i].gameObject, spawnLocation.position, Quaternion.identity);

        }
       
    }
}
