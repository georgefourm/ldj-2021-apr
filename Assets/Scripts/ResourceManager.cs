using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int Amount = 20;

    public GameObject ResourcePrefab;

    public Vector2 lowerLeftBound, upperRightBound;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Amount; i++)
        {
            var resource = Instantiate(ResourcePrefab, transform);
            var x = Random.Range(lowerLeftBound.x, upperRightBound.x);
            var z = Random.Range(lowerLeftBound.y, upperRightBound.y);

            resource.transform.position = new Vector3(x, 0, z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
