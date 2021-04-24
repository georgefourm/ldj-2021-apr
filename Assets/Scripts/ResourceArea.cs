using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceArea : MonoBehaviour
{
    public float minResources = 3;
    public float maxResources = 5;
    public float width;
    public float height;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float hheight = height / 2;
        float hwidth = width / 2;
        Vector3 p = transform.position;

        Vector3 p1 = p + new Vector3(hwidth, 0, hheight);
        Vector3 p2 = p + new Vector3(hwidth, 0, -hheight);
        Vector3 p3 = p + new Vector3(-hwidth, 0, -hheight);
        Vector3 p4 = p + new Vector3(-hwidth, 0, hheight);

        Gizmos.DrawLine(p1, p2);
        Gizmos.DrawLine(p2, p3);
        Gizmos.DrawLine(p3, p4);
        Gizmos.DrawLine(p4, p1);
    }

    public Rect GetBoundingBox()
    {
        Vector3 bottomRightPoint = transform.position + new Vector3(-width/2, 0, -height/2);
        return new Rect(
                bottomRightPoint.x, bottomRightPoint.z, width, height
            );
    }
}
