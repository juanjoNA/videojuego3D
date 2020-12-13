using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailCamera : MonoBehaviour
{
    private Vector3[] nodes;
    private int countNode;
    private int currentNode = 0;

    private void Start()
    {
        countNode = transform.childCount;
        nodes = new Vector3[countNode];

        for(int i = 0; i<countNode; i++)
        {
            nodes[i] = transform.GetChild(i).position;
        }
    }

    private void Update()
    {
        if(countNode > 1)
        {
            for(int i = 0; i < countNode -1; i++)
            {
                Debug.DrawLine(nodes[i], nodes[i + 1], Color.green);
            }
        }
    }

    public Vector3 ProjectPosCameraOnRail(Vector3 pos)
    {
        int closestNode = GetClosestNode(pos);

        if(closestNode == 0)
        {
            return ProjectOnSegment(nodes[0], nodes[1], pos);
        }else if(closestNode == countNode - 1)
        {
            return ProjectOnSegment(nodes[countNode-1], nodes[countNode-2], pos);

        }
        else
        {
            Vector3 leftSegment = ProjectOnSegment(nodes[closestNode - 1], nodes[closestNode], pos);
            Vector3 rightSegment = ProjectOnSegment(nodes[closestNode + 1], nodes[closestNode], pos);

            //Debug.DrawLine(pos, leftSegment, Color.red);
            //Debug.DrawLine(pos, rightSegment, Color.blue);

            if((pos - leftSegment).sqrMagnitude <= (pos - rightSegment).sqrMagnitude)
            {
                return leftSegment;
            }
            else
            {
                return rightSegment;
            }
        }

    }

    private int GetClosestNode(Vector3 pos)
    {
        float shortDistance = 0.0f;

        for (int i = 0; i < countNode; i++)
        {
            Vector3 resta = (nodes[i] - pos);
            float sqrDist = resta.sqrMagnitude;
            if (shortDistance == 0.0f || sqrDist < shortDistance)
            {
                shortDistance = sqrDist;
                currentNode = i;
            }
        }

        return currentNode;
    }

    public Vector3 ProjectOnSegment(Vector3 v1, Vector3 v2, Vector3 pos)
    {
        Vector3 v1ToPos = pos - v1;
        Vector3 segDirection = (v2 - v1).normalized;

        float distanceFromV1 = Vector3.Dot(segDirection, v1ToPos);
        if(distanceFromV1 < 0)
        {
            return v1;
        }else if(distanceFromV1*distanceFromV1 > (v2 - v1).sqrMagnitude)
        {
            return v2;
        }
        else
        {
            Vector3 fromV1 = segDirection * distanceFromV1;
            return v1 + fromV1;
        }
    }

}
