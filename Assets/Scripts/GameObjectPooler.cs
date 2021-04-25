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

    public GameObject InstantiatePooled(string poolName, GameObject prototype)
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
            item.SetActive(true);
            return item;
        }

        return Instantiate(prototype);
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
