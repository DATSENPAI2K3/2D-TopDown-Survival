using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : Damageable
{
    private HealthBar healthBar;
    private void Awake()
    {
        healthBar = GetComponent<HealthBar>();
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (!collision.CompareTag("Enemy")) return;
    //    this.TakeDamage(1);
    //    healthBar.UpdateBar();
    //}
    protected override void OnDead()
    {
        GameManager.Instance.GameOver();
        gameObject.SetActive(false);
    }
}
