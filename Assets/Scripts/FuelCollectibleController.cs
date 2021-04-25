using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCollectibleController : MonoBehaviour
{
    public float Amount = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.fuel.AddFuel(Amount);
            Destroy(gameObject);
        }
    }
}
