using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Vector3 movement = new Vector3(10, 10, 0);
    Rigidbody rb;
    float timeFromPreviousMove;
    public int speed;

    private void Update()
    {
        timeFromPreviousMove += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && timeFromPreviousMove > 0.2f)
        {
            movement.y = -movement.y;
            timeFromPreviousMove = 0.0f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        ReflectProjectile(rb, collision.contacts[0].normal);
    }

    private void ReflectProjectile(Rigidbody rb, Vector3 reflectVector)
    {
        movement = Vector3.Reflect(movement, reflectVector);
        rb.velocity = movement;
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        Vector3 dir = collision.contacts[0].point - transform.position;
        Debug.Log("DIR = " + dir.ToString());
        Debug.Log("DIR NORMALIZED = " + dir.normalized.ToString());
        movement = -dir.normalized*speed;
        
         if(collision.gameObject.tag == "top" || collision.gameObject.tag == "bottom")
         {
             movement.y = -movement.y;
         }
         else if(collision.gameObject.tag == "right" || collision.gameObject.tag == "left")
         {
             movement.x = -movement.x;
         }
}*/


    private void FixedUpdate()
    {
        rb.velocity = movement;
    }

    private void Awake()
    {
        timeFromPreviousMove = 0.0f;
        rb = GetComponent<Rigidbody>();

        rb.AddForce(movement, ForceMode.VelocityChange);
    }
}
