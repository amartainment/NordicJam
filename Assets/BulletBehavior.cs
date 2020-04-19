using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 targetDirection;
    Vector3 initialPos;
    Rigidbody myBody;
    public float bulletSpeed;
    public bool activated = false;
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(activated)
        {
            MoveTowardsTarget();
        }
    }

    public void setTarget(Transform playerPos, Vector3 startPosition)
    {
        targetDirection = playerPos.position - startPosition;
        activated = true;
    }

    void MoveTowardsTarget()
    {

        transform.position += targetDirection.normalized * bulletSpeed * Time.deltaTime;
    }
}
