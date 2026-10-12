using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] AutoAttack autoAttack;
    void Update()
    {
        this.RotateGun();
    }
    private void RotateGun()
    {
        GameObject target = this.autoAttack.FindNearestEnemy();
        if (target == null) return;
        Vector2 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle - 41);
    }
}
