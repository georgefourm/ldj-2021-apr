using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    public GameObject resourcePrefab;

    public int resourcesRequired = 15;

    private int resourcesCollected = 0;

    public void Reset()
    {
        resourcesCollected = 0;    
    }

    public void CollectResource()
    {
        if (resourcesCollected == resourcesRequired)
        {
            return;
        }
        
        resourcesCollected++;
        GameManager.Instance.ui.AddResource();

        if (resourcesCollected == resourcesRequired)
        {
            GameManager.Instance.SetResourcesCompleted();
        }
    }

    public void PopulateResourceAreas()
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
        var resource = Instantiate(resourcePrefab, transform);
        resource.transform.position = new Vector3(x, 0, z);
        resource.transform.eulerAngles += new Vector3(0, 0, Random.Range(0, 360));
    }
}
