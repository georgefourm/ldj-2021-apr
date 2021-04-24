using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 50.0f;

    public Vector3 angleVelocity = new Vector3(0, 16f, 0);

    Rigidbody playerRigidbody;

    private float hInput;
    private float vInput;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        /*
        if (vInput != 0) {
            Vector3 direction = new Vector3(hInput, 0, vInput);
            Debug.Log(direction.normalized);
            rigidbody.AddForce(direction.normalized * speed);
        } else if (hInput != 0) {
            Vector3 direction = new Vector3(hInput, 0, 0); // replace it with the directional constant
            Debug.Log(direction.normalized);
            rigidbody.AddForce(direction * speed * 0.4f);
        }
        */

        Vector3 direction = vInput * Vector3.forward;


    }

    private void FixedUpdate()
    {
        if (hInput != 0)
        {
            Vector3 rotSpeed = vInput != 0 ? angleVelocity * 1.5f : angleVelocity;
            Quaternion deltaRotation = Quaternion.Euler(angleVelocity * Time.fixedDeltaTime * Mathf.Sign(hInput));
            //playerRigidbody.MoveRotation(playerRigidbody.rotation * deltaRotation);
            playerRigidbody.rotation = playerRigidbody.rotation * deltaRotation;
        }

        if (vInput != 0)
        {
            float fwdSpeed = vInput > 0 ? speed * 1.5f : speed;
            playerRigidbody.AddForce(Mathf.Sign(vInput) * transform.forward * fwdSpeed);
        }
    }

    public void FuelCube()
    {
        Debug.Log("Fuel!!!");
    }
}