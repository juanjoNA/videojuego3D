using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateControlPoint : MonoBehaviour
{
    public GameObject wall;
    private bool active;


    public IEnumerator activate()
    {
        if (!active)
        {
            float childs = wall.transform.childCount;
            float t = 1.5f / childs;
            for (int i = 0; i < childs; i++)
            {
                wall.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = true;
                yield return new WaitForSeconds(t);
            }
            wall.GetComponent<BoxCollider>().enabled = true;
            wall.tag = "wall";
            active = true;
        }
    }
}
