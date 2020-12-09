using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteMovement : MonoBehaviour
{
    public float speed;
    public Vector3 movement;
    public float distancePlayer;
    public GameObject player;
    private Rigidbody rb;
    public float top, bottom;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = movement * speed;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = rb.velocity.normalized;
        if (bottom < player.transform.position.y && top > player.transform.position.y)
        {
            Vector3 posPlayer = player.transform.position;
            Vector3 posPalette = transform.position;
            
            float distX = Mathf.Abs(posPlayer.x - posPalette.x);

            if (movement.x != 0)
            {
                if (distX < distancePlayer)
                {
                    float xmax = transform.GetChild(0).position.x;
                    float xmin = xmax + transform.childCount - 1;
                    if (posPlayer.y > xmax || posPlayer.y < xmin)
                    {
                        if (posPlayer.y <= xmax) movement.x = -1;
                        else movement.x = 1;

                        //transform.Translate(movement * speed * 2 * Time.deltaTime);
                        rb.velocity *= 2;
                    }
                }
            }
            else if (movement.y != 0)
            {
                if (distX < distancePlayer)
                {
                    float ymin = transform.GetChild(0).position.y;
                    float ymax = ymin + transform.childCount - 1;
                    if (posPlayer.y > ymax || posPlayer.y < ymin)
                    {
                        if (posPlayer.y > ymax) movement.y = Mathf.Abs(movement.y);
                        else if (movement.y > 0) movement.y *= -1;

                        rb.velocity = movement * speed * 3;
                        //transform.Translate(movement * speed * 5 * Time.deltaTime);
                    }else rb.velocity = movement * speed;
                }
                else rb.velocity = movement * speed;
            }
        }
    }

}
