using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : Damageable
{
    //[SerializeField] EnemySpawner enemySpawner;
    [SerializeField] GameObject manaOrbPrefab;
    protected override void OnDead()
    {
        gameObject.SetActive(false);
        GameObject newManaOrb = Instantiate(manaOrbPrefab, transform.position, Quaternion.identity);
        newManaOrb.SetActive(true);
    }
}

