using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerController : MonoBehaviour
{
    public float speed = 15f;
    public float lifetime = 5f;

    public int damage = 2;

    // Start is called before the first frame update
    void Start()
    {
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
        if (!other.gameObject.tag.Equals("Invisible"))
        {
            GameManager.Instance.health.Damage(damage);
            GameManager.Instance.pooler.DestroyPooled("projectiles", gameObject);
        }
    }
}
