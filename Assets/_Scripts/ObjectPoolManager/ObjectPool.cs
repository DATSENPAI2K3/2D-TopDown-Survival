using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private Dictionary<GameObject, List<GameObject>> pools;
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        pools = new Dictionary<GameObject, List<GameObject>>();
    }
    public GameObject GetObject(GameObject prefab, int initialSize = 10)
    {
        if (!pools.ContainsKey(prefab))
        {
            pools[prefab] = new List<GameObject>();
            for (int i = 0; i < initialSize; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);
                pools[prefab].Add(obj);
            }
        }
        foreach (var obj in pools[prefab])
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        GameObject newObj = Instantiate(prefab);
        pools[prefab].Add(newObj);
        return newObj;
    }
}
