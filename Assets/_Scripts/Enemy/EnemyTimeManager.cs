using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTimeManager : MonoBehaviour
{
    [SerializeField] GameObject orcSpawner;
    [SerializeField] GameObject batSpawner;
    [SerializeField] GameObject bossSpawner;
    float timer = 0f;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 30f && timer < 31f) this.orcSpawner.SetActive(true);
        if (timer > 60f && timer < 61f) this.batSpawner.SetActive(true);
        if (timer > 120f && timer < 121f) this.bossSpawner.SetActive(true);
    }
}
