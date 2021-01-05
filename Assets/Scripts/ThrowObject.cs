using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public Vector3 startClick;
    public Vector3 endClick;
    public float throwForceMultiplier = 1000f;
    public float verticalForce = 1000f;
    private PlayerController playerController;
    public GameObject locationHitPrefab;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        if(playerController.isHolding == true && Input.GetMouseButtonDown(1))
        {
            var ray = playerController.camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Table")))
            {
                if (hit.transform.CompareTag("Table"))
                {
                    startClick = hit.point;
                    GameObject startIndicator = Instantiate(locationHitPrefab, hit.point, Quaternion.identity);
                    Destroy(startIndicator, 3f);
                }
            }
        }

        if (playerController.isHolding == true && Input.GetMouseButtonUp(1))
        {
            var ray = playerController.camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Table")))
            {
                if (hit.transform.CompareTag("Table"))
                {
                    endClick = hit.point;
                    GameObject endIndicator = Instantiate(locationHitPrefab, hit.point, Quaternion.identity);
                    Destroy(endIndicator, 3f);
                }
            }
            Vector3 direction = new Vector3((endClick.x - startClick.x) * -throwForceMultiplier, verticalForce, (endClick.z - startClick.z)*-throwForceMultiplier);
            playerController.isHolding = false;
            playerController.thrown = true;
            playerController.selectedObject.GetComponent<Rigidbody>().AddForce(direction);
            Debug.Log("Direction = " + direction);
            Reset();
        }

    }

    private void Reset()
    {
        startClick = Vector3.zero;
        endClick = Vector3.zero;
        
    }
}
