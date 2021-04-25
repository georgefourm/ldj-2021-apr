using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 10f;

    private Transform playerTransform;
    private Rigidbody enemyRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
        enemyRigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var directionToPlayer = (playerTransform.position - transform.position);
        var directionToPlayerNormalized = directionToPlayer.normalized;
        Quaternion rotation = Quaternion.LookRotation(directionToPlayerNormalized, Vector3.up);
        transform.rotation = rotation;
        Debug.Log(directionToPlayer.magnitude);
        if (directionToPlayer.magnitude > 50.0f && directionToPlayer.magnitude < 100.0f)
        {
            enemyRigidbody.velocity = directionToPlayerNormalized * speed;
        }
        else
        {
            enemyRigidbody.velocity = Vector3.zero;
        }
    }
}
