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

    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
        enemyRigidbody = this.GetComponent<Rigidbody>();
        shootingTimer = shootingTimeInterval;
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
            if (directionToPlayer.magnitude <= minFollowDistance)
            {
                if (shootingTimer < 0)
                {
                    GameObject lazerObject = Instantiate(lazerPrefab);
                    lazerObject.transform.position = transform.position + transform.forward * 4;
                    lazerObject.transform.rotation = rotation;
                    //lazerObject.transform.rotation = Quaternion.Euler(lazerObject.transform.rotation.x, lazerObject.transform.rotation.y, lazerObject.transform.rotation.z + 90);
                    //Quaternion lazerRotation = Quaternion.LookRotation(lazerObject.transform.forward, Vector3.up);

                    //
                    Debug.Log(lazerObject.transform.forward);

                    //Quaternion lazerRotation = Quaternion.LookRotation(lazerObject.transform.forward, Vector3.up);
                    //lazerObject.transform.rotation = Quaternion.Euler(lazerRotation.x, lazerRotation.y, lazerRotation.z);
                }
            }
        }

        if (shootingTimer < 0) shootingTimer = shootingTimeInterval;
    }
}
