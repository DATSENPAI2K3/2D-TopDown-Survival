using System.Collections.Generic;
using UnityEngine;

public class InfiniteMapPool : MonoBehaviour
{
    public Transform player;
    public GameObject mapPrefab;
    public int mapWidth = 28;
    public int mapHeight = 16;
    private Dictionary<Vector2Int, GameObject> activeMaps = new Dictionary<Vector2Int, GameObject>();
    private Vector2Int currentPlayerMap;
    void Start()
    {
        currentPlayerMap = GetPlayerMap();
        UpdateMaps();
    }
    void Update()
    {
        Vector2Int newPlayerMap = GetPlayerMap();
        if (newPlayerMap != currentPlayerMap)
        {
            currentPlayerMap = newPlayerMap;
            UpdateMaps();
        }
    }
    Vector2Int GetPlayerMap()
    {
        int x = Mathf.FloorToInt(player.position.x / mapWidth);
        int y = Mathf.FloorToInt(player.position.y / mapHeight);
        return new Vector2Int(x, y);
    }
    void UpdateMaps()
    {
        HashSet<Vector2Int> neededMaps = new HashSet<Vector2Int>();
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                Vector2Int mapCoord = new Vector2Int(currentPlayerMap.x + x, currentPlayerMap.y + y);
                neededMaps.Add(mapCoord);
                if (!activeMaps.ContainsKey(mapCoord))
                {
                    SpawnMap(mapCoord);
                }
            }
        }
        List<Vector2Int> removeList = new List<Vector2Int>();
        foreach (var map in activeMaps)
        {
            if (!neededMaps.Contains(map.Key))
            {
                map.Value.SetActive(false);
                removeList.Add(map.Key);
            }
        }
        foreach (var coord in removeList)
        {
            activeMaps.Remove(coord);
        }
    }
    void SpawnMap(Vector2Int coord)
    {
        GameObject map = ObjectPool.instance.GetObject(mapPrefab);
        map.transform.position = new Vector3(coord.x * mapWidth, coord.y * mapHeight, 0);
        map.transform.rotation = Quaternion.identity;
        activeMaps.Add(coord, map);
    }
}