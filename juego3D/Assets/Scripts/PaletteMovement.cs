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
    public float ymin, ymax;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < ymin && player.transform.position.y > ymax)
        {
            Vector3 posPlayer = player.transform.position;
            Vector3 posPalette = transform.position;
            float distX = Mathf.Abs(posPlayer.x - posPalette.x);
            float distY = Mathf.Abs(posPlayer.y - posPalette.y);
            Debug.Log("DISTX = " + distX + "\nDISTY = " + distY);
            if (movement.x != 0)
            {
                if (distY < distancePlayer)
                {
                    if (distX> distancePlayer * 2)
                    {

                    }
                    else
                    {

                    }

                    /*
                    Vector3 plPos = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
                    transform.position = Vector3.MoveTowards(transform.position, plPos, (20) * Time.deltaTime);*/
                }
            }
            else if (movement.y != 0)
            {
                if (distX < distancePlayer)
                {
                    if(player.transform.)
                    if (distY >= 5)
                    {
                        if(posPlayer.y > posPalette.y) movement.y = 1;
                        else movement.y = -1;
                        
                        transform.Translate(movement * speed*3);
                    }
                    else if(distY >= 2) transform.Translate(movement * speed * 3);
                    else  transform.Translate(movement * speed);
                    

                    /*
                    Vector3 plPos = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
                    transform.position = Vector3.MoveTowards(transform.position, plPos, (20) * Time.deltaTime);*/
                }
                else
                {
                    transform.Translate(movement * speed);
                }
            }


            
            else if(distX < 50)
            {
                transform.Translate(movement*speed);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (movement.x != 0) movement.x = -movement.x;
        else if (movement.y != 0) movement.y = -movement.y;
        
    }
}
