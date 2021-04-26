using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public float rotatingSpeed = 0.25f;
    private float rotation;

    private void Start()
    {
        rotation = 0f;
    }

    private void Update()
    {
        rotation -= Time.deltaTime * 360f * rotatingSpeed;
        transform.localRotation = Quaternion.Euler(0, rotation, 0);
        if (rotation <= -360f) rotation += 360f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.CompleteLevel();
        }
    }
}
