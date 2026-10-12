using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] GameObject BossPrefab;
    [SerializeField] GameObject player;
    [SerializeField] float spawnRadius = 10f;
    private void Awake()
    {
        this.BossPrefab.SetActive(false);
    }
    private void Start()
    {
        this.Spawner();
    }
    void Spawner()
    {
        if (player == null) return;
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        if (randomDir == Vector2.zero) randomDir = Vector2.up;
        Vector2 spawnPos = (Vector2)player.transform.position + randomDir * spawnRadius;
        GameObject enemy = ObjectPool.instance.GetObject(this.BossPrefab, 1);
        enemy.transform.position = spawnPos;
    }
}
