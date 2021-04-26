using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerController : MonoBehaviour
{
    public float speed = 15f;
    public float maxLifetime = 5f;
    
    float lifetime = 5f;

    public int damage = 10;

    public void Fire()
    {
        lifetime = maxLifetime;
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0) GameManager.Instance.pooler.DestroyPooled("projectiles", gameObject); ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            GameManager.Instance.health.Damage(damage);
        }
        GameManager.Instance.pooler.DestroyPooled("projectiles", gameObject);
    }
}
