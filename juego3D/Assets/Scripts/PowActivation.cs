using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowActivation : MonoBehaviour
{
    public GameObject objChange;
    private float scale = 0.05f;
    private bool start = false;
    private int state;


    void Update()
    {
        if (start)
        {
            if(state < 0)
            {
                for(int i=0; i<transform.childCount; i++)
                {
                    transform.GetChild(i).transform.localScale -= new Vector3(scale, scale, scale);
                }

                if(objChange != null)
                {
                    for (int i = 0; i < objChange.transform.childCount; i++)
                    {
                        objChange.transform.GetChild(i).transform.localScale += new Vector3(scale, scale, scale);
                    }
                }

                if (transform.GetChild(0).transform.localScale.x <= 0.0f)
                {
                    start = false;
                    objChange.GetComponent<BoxCollider>().enabled = true;
                    GetComponent<BoxCollider>().enabled = false;
                }
            }
            else
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).transform.localScale += new Vector3(scale, scale, scale);
                }
                if (objChange != null)
                {
                    for (int i = 0; i < objChange.transform.childCount; i++)
                    {
                        objChange.transform.GetChild(i).transform.localScale -= new Vector3(scale, scale, scale);
                    }
                }

                if (transform.GetChild(0).transform.localScale.x >= 1.0f)
                {
                    start = false;
                    objChange.GetComponent<BoxCollider>().enabled = false;
                    GetComponent<BoxCollider>().enabled = true;
                }
            }
        }

    }

    public void cambiarBloques(int s)
    {
        state = s;
        start = true;
    }

    public bool isFinish()
    {
        return !start;
    }
}
