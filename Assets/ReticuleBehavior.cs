using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticuleBehavior : MonoBehaviour
{
    public Camera mainCam;
    public Camera TwoDCam;
    public Material highlightedMaterial;
    public Material defaultMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //SendRayCasts();
        if(Input.GetMouseButtonDown(0))
        {
            SendRayCast();
        }
    }

    void SendRayCasts()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if(selection.CompareTag("gridPoint"))
            {
                selection.GetComponent<Renderer>().material = highlightedMaterial;
            }
        }
    }

    void SendRayCast()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int layermask = 1 << 9; //cast ray only to screen layer - 9
        int TileLayerMask = 1 << 8; //cast second ray only to tiles
        if (Physics.Raycast(ray, out hit, layermask))
        {
            
            var localPoint = hit.textureCoord;
            Ray TwoDRay = TwoDCam.ViewportPointToRay(localPoint);
            
            RaycastHit TwoDHit;
           
            if (Physics.Raycast(TwoDRay,out TwoDHit, TileLayerMask))
            {
                TwoDHit.collider.gameObject.GetComponent<InteractableTile>().Interact();
                Debug.Log(TwoDHit.collider.gameObject);
            }
        }
    }

   
}
