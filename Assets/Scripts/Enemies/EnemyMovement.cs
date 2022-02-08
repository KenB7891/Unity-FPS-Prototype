using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{        
    private Rigidbody myRigidbody;
    private float xVelocity;
    private float yVelocity;
    private float zVelocity;

    // Start is called before the first frame update
    void Start()
    {        
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        float movementSpeed = GetComponent<Enemy>().speed;

        float xDistance = player.transform.position.x - transform.position.x;
        float zDistance = player.transform.position.z - transform.position.z;

        yVelocity = -0.3f * movementSpeed; 

        if (xDistance >= 0.1f)
        {            
            xVelocity = movementSpeed;
        }
        else if (xDistance <= -0.1f)
        {
            xVelocity = -movementSpeed;
        }
        else
        {
            xVelocity = 0;
        }

        if (zDistance >= 0.1f)
        {
            zVelocity = movementSpeed;
        }
        else if (zDistance <= -0.1f)
        {
            zVelocity = -movementSpeed;
        }
        else
        {
            zVelocity = 0;
        }

    }
    void FixedUpdate()
    {
        myRigidbody.velocity = new Vector3(xVelocity, yVelocity, zVelocity);
    }
}
