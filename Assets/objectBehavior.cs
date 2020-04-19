using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public Material highlighted;
    public GameObject object2D;
    Vector3 holsterPosition;
    public Transform PlacementOffset;
    public GameObject prefab2D;
    public Transform snapTransOffset;
    public Quaternion snapRotationOffset;
    public Transform holster;
    public bool equipped = false;
    public bool used = false;
    public string ObjectType;
    Vector3 initialPos;
    Quaternion initialRotation;
    Vector3 initialScale;
    Material initialMaterial;
    void Start()
    {
        initialPos = transform.position;
        initialRotation = transform.rotation;
        initialScale = transform.localScale;
        initialMaterial = GetComponentInChildren<Renderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(Transform itemHolder)
    {
        
            
            
            transform.position = itemHolder.position;
            transform.rotation = Quaternion.Euler(-9.32f, -131.8f, 0f);
            Vector3 offset;
            holsterPosition = transform.position;
            holster = itemHolder;
            transform.parent = itemHolder;
            transform.localScale = new Vector3(0.09f, 0.09f, 0.09f);
            equipped = true;
            //GetComponent<BoxCollider>().enabled = false;
        

       
    }

    public void Remove()
    {
        if (used)
        {
            equipped = true;
            used = false;

            transform.localScale = new Vector3(0.09f, 0.09f, 0.09f);
            transform.position = holsterPosition;
            transform.rotation = Quaternion.Euler(-9.32f, -131.8f, 0f);
            Vector3 offset;
            transform.parent = holster;

            if (object2D != null && ObjectType!="dart")
            {
                Destroy(object2D);
            }
        }
    }

    private void OnMouseOver()
    {
        GetComponentInChildren<Renderer>().material = highlighted;    
    }

    private void OnMouseExit()
    {
        GetComponentInChildren<Renderer>().material = initialMaterial;
    }
    public void returnToStart()
    {
        equipped = false;
        used = false;
        transform.parent = null;
        transform.localScale = initialScale;
        transform.position = initialPos;
        transform.rotation = initialRotation;
        

    }

    public void Use(Vector3 position)
    {
        transform.parent = null;

        Vector3 offset = PlacementOffset.localPosition;
        transform.localScale = new Vector3(0.055f, 0.055f, 0.055f);
        transform.position = position + offset;
        if (ObjectType == "postit")
        {
            transform.right = Vector3.left;
            transform.up = Vector3.up;
            transform.forward = Vector3.back;
            transform.position = new Vector3(transform.position.x, transform.position.y, 1.31f);
        }

        if (ObjectType == "dart")
        {
            transform.right = Vector3.right;
            transform.up = Vector3.forward;
            transform.forward = Vector3.up;
            transform.position = new Vector3(transform.position.x, transform.position.y, 1.31f);
        }
        GetComponent<BoxCollider>().enabled = true;
        used = true;
        equipped = false;
        GameObject.Find("_gm").GetComponent<ReticuleBehavior>().currentObject = null;
        
    }

    public void setObject2D(GameObject obj)
    {
        object2D = obj;
    }
}
