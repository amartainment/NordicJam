using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundTouch : MonoBehaviour
{
    public PlayerBehavior2D dude;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SendRays();
    }

    void SendRays()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
        {
            if (hit.collider.CompareTag("platform"))
            {
                dude.checkForGround(true);
            }
            
        }
        else
        {
            dude.checkForGround(false);
        }
        
    }

    
}
