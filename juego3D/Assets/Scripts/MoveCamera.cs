using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private int actualRoom, nextRoom;
    private bool active, move;
    public GameObject puntosCamaras, camara;


    void Start()
    {
        actualRoom = 0;
        nextRoom = 0;
        active = false;
    }
    void Update()
    {
        if (actualRoom != nextRoom)
        {
            if (camara.transform.position != puntosCamaras.transform.GetChild(nextRoom).transform.position)
            {
                Vector3 moveVector = (camara.transform.position - puntosCamaras.transform.GetChild(nextRoom).transform.position).normalized;
                moveVector = moveVector * 10 * Time.deltaTime;
                if (moveVector.x != 0)
                {
                    if(moveVector.x > 0)
                    {
                        if (camara.transform.position.x - moveVector.x < puntosCamaras.transform.GetChild(nextRoom).transform.position.x)
                            camara.transform.position = puntosCamaras.transform.GetChild(nextRoom).transform.position;
                        else
                            camara.transform.Translate(moveVector);
                    }
                    else
                    {
                        if (camara.transform.position.x + moveVector.x > puntosCamaras.transform.GetChild(nextRoom).transform.position.x)
                            camara.transform.position = puntosCamaras.transform.GetChild(nextRoom).transform.position;
                        else
                            camara.transform.Translate(moveVector);
                    }
                }else if (moveVector.y != 0)
                {
                    if (moveVector.y > 0)
                    {
                        if (camara.transform.position.y - moveVector.y < puntosCamaras.transform.GetChild(nextRoom).transform.position.y)
                            camara.transform.position = puntosCamaras.transform.GetChild(nextRoom).transform.position;
                        else
                            camara.transform.Translate(-moveVector);
                    }
                    else
                    {
                        if (camara.transform.position.y - moveVector.y > puntosCamaras.transform.GetChild(nextRoom).transform.position.y)
                            camara.transform.position = puntosCamaras.transform.GetChild(nextRoom).transform.position;
                        else
                            camara.transform.Translate(-moveVector);
                    }
                }
                else
                {
                    Debug.Log("No deberia pasar");
                }
            }
            else
            {
                actualRoom = nextRoom;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            nextRoom = int.Parse(other.name.Substring(other.name.Length - 1));
            active = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!active)
        {
            active = true;
        }
    }


}
