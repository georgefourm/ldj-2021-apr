using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPooler : MonoBehaviour
{

    Dictionary<string, Stack<GameObject>> pools = new Dictionary<string, Stack<GameObject>>();

    public void CreatePool(string name)
    {
        var pool = new Stack<GameObject>();
        if (!pools.ContainsKey(name))
        {
            pools.Add(name, pool);
        }
    }

    public GameObject InstantiatePooled(string poolName, GameObject prototype, Vector3 position, Quaternion rotation)
    {
        if (!pools.ContainsKey(poolName))
        {
            Debug.LogWarning("Tried to instantiate object from non-existing pool: " + poolName);
            return null;
        }
        var pool = pools[poolName];

        if (pool.Count > 0)
        {
            var item = pool.Pop();
            item.transform.position = position;
            item.transform.rotation = rotation;
            item.SetActive(true);
            return item;
        }

        return Instantiate(prototype,position,rotation);
    }

    public void DestroyPooled(string poolName, GameObject item)
    {
        if (!pools.ContainsKey(poolName))
        {
            Debug.LogWarning("Tried to add object to non-existing pool: " + poolName);
            return;
        }
        var pool = pools[poolName];
        pool.Push(item);
        item.SetActive(false);
    }
}
