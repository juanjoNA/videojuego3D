using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToDie : MonoBehaviour
{
    private bool colision = false;
    public float timeToDie = 6.0f;

    // Update is called once per frame
    void Update()
    {
        if (colision)
        {
            timeToDie -= Time.deltaTime;
            if (timeToDie <= 0.0f)
                Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        colision = true;
    }


}
