using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateControlPoint : MonoBehaviour
{
    public GameObject wall;
    private bool active;

    private void Start()
    {

    }


    public IEnumerator activate()
    {
        if (!active)
        {
            int childs = wall.transform.childCount;
            for (int i = 0; i < childs; i++)
            {
                wall.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = true;
                yield return new WaitForSeconds(0.5f);
            }
            wall.GetComponent<BoxCollider>().enabled = true;
            wall.tag = "wall";
            active = true;
        }
    }
}
