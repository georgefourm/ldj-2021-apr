using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
 //   public int Amount = 20;

    public GameObject ResourcePrefab;

    public Vector2 lowerLeftBound, upperRightBound;

    void Start()
    {
        GameObject[] areas = GameObject.FindGameObjectsWithTag("ResourceArea");
        foreach (GameObject area in areas)
        {
            ResourceArea resourceArea = area.GetComponent<ResourceArea>();
            for (int i=0; i<resourceArea.minResources; i++)
            {
                Rect bb = resourceArea.GetBoundingBox();
                var x = Random.Range(bb.x, bb.x + bb.width);
                var z = Random.Range(bb.y, bb.y + bb.height);
                GenerateResource(x, z);
            }
        }
    }

    private void GenerateResource(float x, float z)
    {
        var resource = Instantiate(ResourcePrefab, transform);
        resource.transform.position = new Vector3(x, 0, z);
        resource.transform.eulerAngles += new Vector3(0, 0, Random.Range(0, 360));
    }
}
