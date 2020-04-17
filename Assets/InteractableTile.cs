using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTile : MonoBehaviour
{
    BoxCollider myCollider;
    public Sprite platformSprite;
    Sprite currentSprite;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider>();
        myCollider.isTrigger = true;
        currentSprite = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if(myCollider.isTrigger)
        {
            myCollider.isTrigger = false;
            GetComponent<SpriteRenderer>().sprite = platformSprite;
        } else
        {
            myCollider.isTrigger = true;
            GetComponent<SpriteRenderer>().sprite = currentSprite;
        }
    }
}
