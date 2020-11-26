using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementCamera : MonoBehaviour
{
    Vector3 distance;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        distance = player.transform.position - transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position - distance;
    }


}
