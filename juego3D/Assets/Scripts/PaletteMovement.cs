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
    }

    // Update is called once per frame
    void Update()
    {
        if (bottom < player.transform.position.y && top > player.transform.position.y)
        {
            Vector3 posPlayer = player.transform.position;
            Vector3 posPalette = transform.position;
            
            float distX = Mathf.Abs(posPlayer.x - posPalette.x);
            float distY = Mathf.Abs(posPlayer.y - posPalette.y);

            if (movement.x != 0)
            {
                if (distX < distancePlayer)
                {
                    float xmax = transform.GetChild(0).position.x;
                    float xmin = xmax + transform.childCount-1;
                    if (posPlayer.y > xmax || posPlayer.y < xmin)
                    {
                        if (posPlayer.y <= xmax) movement.x = -1;
                        else movement.x = 1;

                        transform.Translate(movement * speed * 2 * Time.deltaTime);
                    }
                }
                else transform.Translate(movement * speed * Time.deltaTime);

            }
            else if (movement.y != 0)
            {
                if (distX < distancePlayer)
                {
                    float ymin = transform.GetChild(0).position.y;
                    float ymax = ymin + transform.childCount-1;
                    if (posPlayer.y > ymax || posPlayer.y < ymin)
                    {
                        if(posPlayer.y > ymax) movement.y = 1;
                        else movement.y = -1;
                        
                        transform.Translate(movement * speed * 5 * Time.deltaTime);
                    }
                    else  transform.Translate(movement * speed * Time.deltaTime);
                    
                }
                else
                {
                    transform.Translate(movement * speed * Time.deltaTime);
                }
            }
        }
        else
        {
            transform.Translate(movement * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "wall")
        {
            float newPos;
            if (movement.x != 0)
            {
                if (movement.x > 0)  newPos = collision.collider.transform.position.x - transform.childCount;
                else  newPos = collision.collider.transform.position.x + 1;
                movement.x = -movement.x;
                transform.position = new Vector3(newPos, transform.position.y, transform.position.z);
            }
            else if (movement.y != 0)
            {
                if (movement.y > 0) newPos = collision.collider.transform.position.y - transform.childCount;
                else newPos = collision.collider.transform.position.y + collision.collider.bounds.size.y;
                movement.y = -movement.y;
                transform.position = new Vector3(transform.position.x, newPos, transform.position.z);
            }
        }
        
    }
}
