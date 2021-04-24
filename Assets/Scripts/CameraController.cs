using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float followSharpness = 0.1f;

    public Transform player;

    public Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }


    void LateUpdate()
    {
        // No need for the "if" - we'll practically never reach exactly 0 distance anyway.

        // Compute our exponential smoothing factor.
        float blend = 1f - Mathf.Pow(1f - followSharpness, Time.deltaTime * 30f);

        transform.position = Vector3.Lerp(
               transform.position,
               player.transform.position + offset,
               blend);
    }
}
