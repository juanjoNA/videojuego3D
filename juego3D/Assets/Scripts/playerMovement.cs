using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Vector3 movement = new Vector3(5, 5, 0);
    Rigidbody rb;
    float timeFromPreviousMove;

    private void Update()
    {
        timeFromPreviousMove += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && timeFromPreviousMove > 0.5f)
        {
            movement.y = -movement.y;
            timeFromPreviousMove = 0.0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "top" || collision.gameObject.tag == "bottom")
        {
            movement.y = -movement.y;
        }
        else if(collision.gameObject.tag == "right" || collision.gameObject.tag == "left")
        {
            movement.x = -movement.x;
        }
    }


    private void FixedUpdate()
    {
        rb.velocity = movement;
    }

    private void Awake()
    {
        timeFromPreviousMove = 0.0f;
        rb = GetComponent<Rigidbody>();
    }
}
