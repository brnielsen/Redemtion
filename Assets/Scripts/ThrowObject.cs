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

    bool applyForce = false;

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
            applyForce = true;
        }

    }

    private void FixedUpdate()
    {
        if (applyForce)
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
            float magnitude = Vector3.Distance(endClick, startClick);
            Vector3 direction = (startClick - endClick).normalized;
            Vector3 forceApplied = new Vector3(0f, verticalForce, direction.z * throwForceMultiplier);

            playerController.isHolding = false;
            playerController.thrown = true;
            playerController.heldObject.GetComponent<Rigidbody>().AddForce(forceApplied, ForceMode.Impulse);
            Debug.Log("Direction = " + direction);
            Debug.Log("Magnitude is " + magnitude);

            Debug.Log("Force Applied = " + forceApplied);

            Reset();
        }
    }

    private void Reset()
    {
        startClick = Vector3.zero;
        endClick = Vector3.zero;
        applyForce = false;
    }
}
