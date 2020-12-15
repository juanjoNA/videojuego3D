using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gadget : MonoBehaviour
{
    public AudioSource gadgetPeripherial;

    void OnCollisionEnter(Collision collision)
    {
        gadgetPeripherial.Stop();
    }

    // Start is called before the first frame update
    void Start()
    {
        gadgetPeripherial.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
