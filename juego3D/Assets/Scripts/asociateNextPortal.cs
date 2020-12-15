using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asociateNextPortal : MonoBehaviour
{
    public GameObject nextPortal;
    private bool canTeleport = true;

    public void setTeleport(bool teleport)
    {
        canTeleport = teleport;
    }
    public bool getCanTeleport()
    {
        return canTeleport;
    }
    public GameObject getNextPortal()
    {
        return nextPortal;
    }
}
