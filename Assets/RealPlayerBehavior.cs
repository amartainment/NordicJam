using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealPlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ItemHolder;
    public int currentItem;
    
    void Start()
    {
        SelectItem();
    }

    
    // Update is called once per frame
    void Update()
    {
        int previousItem = currentItem;
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (currentItem >= ItemHolder.childCount - 1)
            {
                currentItem = 0;
            }
            else
            {
                currentItem++;
            }
            
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
           if(currentItem <=0)
            {
                currentItem = ItemHolder.childCount - 1;
            } else
            {
                currentItem--;
            }

        }

        if(previousItem != currentItem)
        {
            SelectItem();
        }
    }

    void SelectItem()
    {
        int i = 0;
        foreach( Transform item in ItemHolder )
        {
            if(i == currentItem)
            {
                item.gameObject.SetActive(true);
            }
            else
            {
                item.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
