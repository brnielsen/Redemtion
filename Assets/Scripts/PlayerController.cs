using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Class for picking up and yeeting objects

    public Camera camera;

    public GameObject selectedObject;

    public bool isHolding = false;

    private float mousePosX, mousePosY;

    public Material highlightedMaterial;

    private Transform _selection;


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
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();            
            if (selectionRenderer != null && selection.CompareTag("selectable"))
            {
                selectionRenderer.material = highlightedMaterial;
                _selection = selection;
            }

           
        }
        if (Input.GetMouseButtonDown(0))
        {
            //pickup

        }
    }
}
