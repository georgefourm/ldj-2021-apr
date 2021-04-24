using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{

    public GameObject collectible;

    public float padding = 0.05f;

    // Start is called before the first frame update
    void Update()
    {
        Camera camera = Camera.main;
        Vector3 collectiblePosition = collectible.transform.position;
        Vector3 viewportRelative = camera.WorldToViewportPoint(collectiblePosition);

        bool xInRange = viewportRelative.x > 0 && viewportRelative.x < 1;
        bool yInRange = viewportRelative.y > 0 && viewportRelative.y < 1;

        if (xInRange && yInRange)
        {
            transform.localScale = Vector3.zero;
            return;
        }
        else if(transform.localScale.magnitude == 0)
        {
            transform.localScale = Vector3.one;
        }


        float x = Mathf.Clamp01(viewportRelative.x);
        float y = Mathf.Clamp01(viewportRelative.y);
        float yRotation = 0;

        if (viewportRelative.x < 0)
        {
            // We are outside the left bound
            yRotation = -90;
            x += padding;
        }
        if (viewportRelative.x > 1)
        {
            // We are outside the right bound
            yRotation = 90;
            x -= padding;
        }
        if (viewportRelative.y < 0)
        {
            // We are below the bottom bound
            yRotation = yRotation == 0 ? 180 : yRotation + Mathf.Sign(yRotation) * 45;
            y += padding;
        }
        if (viewportRelative.y > 1)
        {
            // We are above the top bound
            yRotation = yRotation == 0 ? 0 : yRotation - Mathf.Sign(yRotation) * 45;
            y -= padding;
        }

        transform.rotation = Quaternion.Euler(0, yRotation, 0);
        transform.position = camera.ViewportToWorldPoint(new Vector3(x, y, viewportRelative.z));
    }
}
