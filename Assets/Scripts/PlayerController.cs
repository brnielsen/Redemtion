using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Class for picking up and yeeting objects

    public Camera camera;

    public Transform selectedObject;

    public Transform nullObjectCauseIcantTellUnityToNullATransform;

    public bool isHolding = false;

    public bool thrown = false;

    private float mousePosX, mousePosY;

    public Material highlightedMaterial;

    private Transform _selection;

    public LayerMask tableMask;

    public float hoverAboveTable = 0.1f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(_selection != null)
        {
            var _selectionRenderer = _selection.GetComponent<Renderer>();
            _selectionRenderer.material = _selection.GetComponent<SelectableObject>().defaultMaterial;
            _selection = null;
        }
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("selectable"))
            {
                selectedObject = hit.transform;
                var selectionRenderer = selectedObject.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightedMaterial;
                    _selection = selectedObject;
                    if (Input.GetMouseButton(0) && thrown == false)
                    {
                        //pickup
                        isHolding = true;
                    }
                }
            }

            if(isHolding == true)
            {
                var positionRay = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit tableHit;
                if (Physics.Raycast(positionRay, out tableHit, Mathf.Infinity, tableMask))
                {
                    selectedObject.position = tableHit.point + new Vector3(0f, hoverAboveTable, 0f);
                }
            }
            if (!Input.GetMouseButton(0))
            {
                isHolding = false;
                thrown = false;
            }
        }
    }
}
