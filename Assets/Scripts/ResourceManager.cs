using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    public GameObject resourcePrefab;

    public int totalResources = 15;

    private int currResources = 0;

    private List<ResourceArea> areas;

    private List<GameObject> resources = new List<GameObject>();

    private void Start()
    {
        GameObject[] areaObjects = GameObject.FindGameObjectsWithTag("ResourceArea");
        areas = new List<ResourceArea>(areaObjects.Length);
        foreach (GameObject area in areaObjects)
        {
            areas.Add(area.GetComponent<ResourceArea>());
        }
    }

    public void Reset()
    {
        currResources = 0;
        foreach (var resource in resources)
        {
            GameManager.Instance.pooler.DestroyPooled("resources", resource);
        }
        resources.Clear();
        PopulateResourceAreas();
    }

    public void CollectResource(GameObject resource)
    {
        if (currResources == totalResources)
        {
            return;
        }
        
        currResources++;
        resources.Remove(resource);

        GameManager.Instance.ui.AddResource();
        GameManager.Instance.pooler.DestroyPooled("resources", resource);

        if (currResources == totalResources)
        {
            GameManager.Instance.SetResourcesCompleted();
        }
    }

    public void PopulateResourceAreas()
    {
        foreach (ResourceArea resourceArea in areas)
        {
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
        var resource = GameManager.Instance.pooler.InstantiatePooled("resources",resourcePrefab);
        resource.transform.position = new Vector3(x, 0, z);
        resource.transform.eulerAngles += new Vector3(0, 0, Random.Range(0, 360));
        resources.Add(resource);
    }
}
