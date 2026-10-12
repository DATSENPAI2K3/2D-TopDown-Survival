using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject player;
    [SerializeField] float spawnRadius = 10f;
    [SerializeField] float timeDelay = 2f;
    float timeStart = 900f;
    [SerializeField] int enemyInRadius = 20;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float checkRadius = 15f;
    private void Awake()
    {
        this.enemyPrefab.SetActive(false);
    }
    void Update()
    {
        this.Spawner();
    }
    void Spawner()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(this.player.transform.position, this.checkRadius, this.enemyLayer);
        if (hits.Length > this.enemyInRadius) return;
        this.timeStart += Time.deltaTime;
        if (this.timeStart < this.timeDelay) return;
        this.timeStart = 0f;
        if (player == null) return;
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        if (randomDir == Vector2.zero) randomDir = Vector2.up;
        Vector2 spawnPos = (Vector2)player.transform.position + randomDir * spawnRadius;
        GameObject enemy = ObjectPool.instance.GetObject(this.enemyPrefab, 20);
        enemy.transform.position = spawnPos;
    }
}
