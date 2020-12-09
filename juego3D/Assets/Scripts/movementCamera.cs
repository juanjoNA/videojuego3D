using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementCamera : MonoBehaviour
{
    public RailCamera rail;
    public Transform lookAt;
    public bool smoothMove = true;
    public float speed = 5.0f;

    private Transform thisTransform;
    private Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        thisTransform = transform;
        lastPosition = transform.position;
    }

    void LateUpdate()
    {
        if (smoothMove)
        {
            lastPosition = Vector3.Lerp(lastPosition, rail.ProjectPosCameraOnRail(lookAt.position), speed * Time.deltaTime);
            thisTransform.position = lastPosition;
        }
        else
        {
            thisTransform.position = rail.ProjectPosCameraOnRail(lookAt.position);
        }
    }


}
