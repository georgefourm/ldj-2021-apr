using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalPull : MonoBehaviour
{
    public float multiplier = 1f;

    private SphereCollider sphereCollider;

    // Start is called before the first frame update
    void Start()
    {
        sphereCollider = gameObject.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider collider)
    {
        var distanceFromCenter = Vector3.Distance(collider.attachedRigidbody.transform.position, transform.position);
        var direction = -(collider.attachedRigidbody.transform.position - transform.position).normalized;
        if (collider.attachedRigidbody)
        {
            var mod = distanceFromCenter == 0 ? 0 : sphereCollider.radius / distanceFromCenter;
            var force = direction * mod * multiplier;
            collider.attachedRigidbody.AddForce(force);
        }
    }

    void OnTriggerExit(Collider collider) {
        //
    }
}
