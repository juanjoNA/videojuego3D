using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteMovement : MonoBehaviour
{
    public float speed = 5;
    public GameObject player;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*float dist = Mathf.Abs(Vector3.Distance(player.transform.position, transform.position));
        if(dist < 10)
        {
            float dif;
            dif = player.transform.position.y - transform.position.y;
            if(dif > 5) rb.velocity = new Vector3(0, speed*2, 0);
            else if(dif < 5) rb.velocity = new Vector3(0, -speed * 2, 0);
            else rb.velocity = new Vector3(0, speed, 0);
        }
        else
        {*/
            transform.Translate(0.0f, speed*Time.deltaTime, 0.0f);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        speed = -speed;
    }
}
