using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageReceiver : Damageable
{
    Animator animator;
    [SerializeField] GameObject gameWinUI;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    protected override void OnDead()
    {
        animator.SetTrigger("Die");
        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<EnemyAttack>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }
    public void BossDeadFinished()
    {
        this.gameWinUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
