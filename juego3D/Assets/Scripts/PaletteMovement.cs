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
    public float ymin_, ymax_;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            Vector3 posPlayer = player.transform.position;
            Vector3 posPalette = transform.position;
            
            float distX = Mathf.Abs(posPlayer.x - posPalette.x);
            float distY = Mathf.Abs(posPlayer.y - posPalette.y);

            if (movement.x != 0)
            {
                if (true)
                {
                    if (distX> distancePlayer * 2)
                    {

                    }
                    else
                    {

                    }
                }
            }
            else if (movement.y != 0)
            {
                if (distX < distancePlayer)
                {
                    float ymax = transform.GetChild(0).position.y;
                    float ymin = ymax+transform.childCount;
                    float y = (ymax + ymin) / 2;
                    if (posPlayer.y >= y+2 || posPlayer.y <= y-2)
                    {
                        if(posPlayer.y <= y-2) movement.y = -1;
                        else movement.y = 1;
                        
                        transform.Translate(movement * speed*3 * Time.deltaTime);
                    }
                    else  transform.Translate(movement * speed * Time.deltaTime);
                    
                }
                else
                {
                    transform.Translate(movement * speed * Time.deltaTime);
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
