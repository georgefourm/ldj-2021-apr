using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalPull : MonoBehaviour
{
    public float scale = 1f;

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
        //Vector3 distance = Vector3.Distance();
        var direction = -(collider.attachedRigidbody.transform.position - transform.position);
        if (collider.attachedRigidbody)
        {
            var mod = 1 / Mathf.Pow(direction.magnitude, 2);
            var force = direction * mod * scale;
            collider.attachedRigidbody.AddForce(force);
        }
    }

    void OnTriggerExit(Collider collider) {
        //
    }
}
