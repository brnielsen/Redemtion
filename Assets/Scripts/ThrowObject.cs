using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public Vector3 startClick;
    public Vector3 endClick;
    public float throwForceMultiplier = 1000f;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        if(playerController.isHolding == true && Input.GetMouseButtonDown(1))
        {
            startClick = Input.mousePosition;
        }

        if (playerController.isHolding == true && Input.GetMouseButtonUp(1))
        {
            endClick = Input.mousePosition;
            Vector3 direction = new Vector3((endClick.x - startClick.x) * throwForceMultiplier, 1000f, 0f);
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
