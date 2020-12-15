using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionCameras : MonoBehaviour
{
    public GameObject sectionPos;
    public float speed;
    private bool activate = false;
    private Vector3 posIni;
    private GameObject cam;
    private float elapsedTime;

    private void Start()
    {
        cam = GameObject.Find("Main Camera");
    }



    // Update is called once per frame
    void Update()
    {
        if (activate)
        {
            if (cam.transform.position == sectionPos.transform.position) activate = false;
            else
            {
                elapsedTime += Time.deltaTime;
                cam.transform.position = Vector3.Lerp(posIni, sectionPos.transform.position, speed * elapsedTime);
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            elapsedTime = 0.0f;
            activate = true;
            posIni = cam.transform.position;
        }
    }
}
