using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarLava : MonoBehaviour
{
    public GameObject proyectil;
    public float maxSpeed, maxTimeBetweenShots, maxNumShots;

    private float speed;
    private float timeToDie = 10.0f;
    private float shots;
    private float timeBetweenShots;
    private float timeToProjectil;

    private bool colision = false;
    private float xmin, xmax;
        
    void Start()
    {
        xmin = 0 - GetComponent<MeshRenderer>().bounds.size.x / 2;
        xmax = 0 + GetComponent<MeshRenderer>().bounds.size.x / 2;
        refresh();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBetweenShots >= 0)
        {
            timeBetweenShots -= Time.deltaTime;
            timeToProjectil -= Time.deltaTime;
            if (timeToProjectil <= 0)
            {
                timeToProjectil = timeBetweenShots / shots;
                GameObject obj = (GameObject)Instantiate(proyectil, transform.position + new Vector3(Random.Range(xmin, xmax), 0.6f, 0.0f), Quaternion.Euler(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f)));
                obj.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(0.0f, 2.0f), speed, 0.0f);
            }

        }
        else refresh();
        
        if (colision)
        {
            timeToDie -= Time.deltaTime;
            if (timeToDie <= 0.0f)
                Destroy(proyectil.gameObject);
        }
    }

    private void refresh()
    {
        speed = Random.Range(maxSpeed-5, maxSpeed);
        shots = Random.Range(maxNumShots/4, maxNumShots);
        timeBetweenShots = Random.Range(maxTimeBetweenShots/2, maxTimeBetweenShots);
        timeToProjectil = timeBetweenShots/shots;
    }


}
