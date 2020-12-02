using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementCamera : MonoBehaviour
{
    public RailCamera rail;
    public Transform lookAt;

    private Transform thisTransform;

    // Start is called before the first frame update
    void Start()
    {
        thisTransform = transform;
    }

    void LateUpdate()
    {
        thisTransform.position = rail.ProjectPosCameraOnRail(lookAt.position);

        //thisTransform.LookAt(lookAt.position);
    }


}
