using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float fireRate = 0.5f;
    float timer;
    void Update()
    {
        this.Auto();
    }
    void Auto()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.fireRate) return;
        this.timer = 0f;
        GameObject target = FindNearestEnemy();
        if (target == null) return;
        this.Fire(target);
    }
    void Fire(GameObject target)
    {
        GameObject bullet = ObjectPool.instance.GetObject(bulletPrefab, 20);
        AudioManager.Instance.PlayGunSound();
        bullet.transform.position = firePoint.position;
        Vector2 dir = target.transform.position - firePoint.position;
        bullet.GetComponent<Bullet>().SetDirection(dir);
    }
    public GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0) return null;
        GameObject nearest = null;
        float minDist = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float dist = Vector2.Distance(transform.position, enemy.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                nearest = enemy;
            }
        }
        return nearest;
    }
}
