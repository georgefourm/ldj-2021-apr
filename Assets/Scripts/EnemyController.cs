using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject lazerPrefab;
    public float speed = 15f;
    public float minFollowDistance = 50f;
    public float maxFollowDistance = 100f;
    public float shootingTimeInterval = 1f;

    private Transform playerTransform;
    private Rigidbody enemyRigidbody;
    private float shootingTimer;
    private Vector3? initPosition = null;

    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
        enemyRigidbody = this.GetComponent<Rigidbody>();
        shootingTimer = shootingTimeInterval;
        initPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var directionToPlayer = playerTransform.position - transform.position;
        var directionToPlayerNormalized = directionToPlayer.normalized;
        Quaternion rotation = Quaternion.LookRotation(directionToPlayerNormalized, Vector3.up);
        transform.rotation = rotation;
        shootingTimer -= Time.deltaTime;

        if (directionToPlayer.magnitude > minFollowDistance && directionToPlayer.magnitude < maxFollowDistance)
        {
            enemyRigidbody.velocity = directionToPlayerNormalized * speed;
        }
        else
        {
            enemyRigidbody.velocity = Vector3.zero;
            if (directionToPlayer.magnitude <= minFollowDistance && shootingTimer < 0)
            {
                Vector3 position = transform.position + transform.forward * 4; 
                GameObject lazerObject = Instantiate(
                  lazerPrefab, position, rotation
                );
             
              lazerObject.GetComponent<LazerController>().Fire();
            }
        }

        if (shootingTimer < 0) shootingTimer = shootingTimeInterval;
    }

    public void Reset()
    {
        if (initPosition != null)
            transform.position = (Vector3) initPosition;
    }


}
