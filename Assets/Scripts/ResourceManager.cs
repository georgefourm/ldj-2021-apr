using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    public GameObject resourcePrefab;

    private int totalResources = 0;

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
        foreach (var area in areas)
        {
            totalResources += (int) area.minResources;
        }

        GameManager.Instance.ui.InitResources(totalResources);
    }

    public void Reset()
    {
        currResources = 0;
        foreach (var resource in resources)
        {
            GameManager.Instance.pooler.DestroyPooled("resources", resource);
        }
        resources.Clear();
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

        if (currResources >= totalResources)
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
        Vector3 position = new Vector3(x, 0, z); ;
        Vector3 rotation = resourcePrefab.transform.eulerAngles + new Vector3(0, 0, Random.Range(0, 360));
        var resource = GameManager.Instance.pooler.InstantiatePooled("resources",resourcePrefab,position,Quaternion.Euler(rotation));
        resources.Add(resource);
    }

    public int GetTotalResouces()
    {
        return totalResources;
    }
}
