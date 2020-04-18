using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTile : MonoBehaviour
{
    BoxCollider myCollider;
    public Sprite platformSprite;
    Sprite currentSprite;
    public bool turned = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(string item, GameObject prefab2D, objectBehavior realObject, Vector3 pos)
    {
        /*
        if(myCollider.isTrigger)
        {
            myCollider.isTrigger = false;
            gameObject.tag = "platform";
            GetComponent<SpriteRenderer>().sprite = platformSprite;
        } else
        {
            myCollider.isTrigger = true;
            gameObject.tag = "wall";
            GetComponent<SpriteRenderer>().sprite = currentSprite;
        }
        */

        if(!turned)
        {
            Vector3 offset = new Vector3(0, 0, -0.2f);
            
            GameObject object2D = Instantiate(prefab2D, transform.position + offset, Quaternion.Euler(0,0,180),null);
            realObject.setObject2D(object2D);
            
        }
    }
}
