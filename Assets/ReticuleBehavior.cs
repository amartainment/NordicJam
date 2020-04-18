using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticuleBehavior : MonoBehaviour
{
    public Camera mainCam;
    public Camera TwoDCam;
    public objectBehavior currentObject;
    public Material highlightedMaterial;
    public Material defaultMaterial;
    public Transform itemHolder;
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
            Send2DRayCast();
            Send3DRayCast();
        }
    }

    void Send3DRayCast()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int layermask = 1 << 11; //only check for object layers
        if (Physics.Raycast(ray, out hit, layermask))
        {
            if(hit.collider.CompareTag("object"))
            {
                
                objectBehavior thisObject = hit.collider.GetComponent<objectBehavior>();
                if (currentObject == null)
                {
                    if (!thisObject.equipped)
                    {
                        currentObject = thisObject;
                        thisObject.Interact(itemHolder);
                        thisObject.equipped = true;
                        Debug.Log("object equip");
                    } else
                    {
                        thisObject.returnToStart();
                        Debug.Log("object return");
                    }
                } else
                {
                    if(thisObject.equipped)
                    {
                        thisObject.returnToStart();
                        currentObject = null;
                    } else
                    {
                        currentObject.returnToStart();
                        currentObject = thisObject;
                        thisObject.Interact(itemHolder);
                    }
                   
                }

                if(thisObject.used)
                {
                    thisObject.Remove();
                }
            }
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

    void Send2DRayCast()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int layermask = 1 << 9; //cast ray only to screen layer - 9
        int TileLayerMask = 1 << 8; //cast second ray only to tiles
        if (Physics.Raycast(ray, out hit, layermask))
        {
            Vector3 moddedHitPoint;
            var localPoint = hit.textureCoord;
           
            Ray TwoDRay = TwoDCam.ViewportPointToRay(localPoint);
            
            RaycastHit TwoDHit;
           
            if (Physics.Raycast(TwoDRay,out TwoDHit, TileLayerMask))
            {
                if (currentObject != null)
                {
                    if (!currentObject.used)
                    {
                        moddedHitPoint = new Vector3(hit.point.x, hit.point.y, 1.3f);

                        TwoDHit.collider.gameObject.GetComponent<InteractableTile>().Interact("a", currentObject.prefab2D, currentObject, TwoDHit.point);
                        currentObject.Use(moddedHitPoint);
                    }
                }
            
               
            }
        }
    }

   
}
