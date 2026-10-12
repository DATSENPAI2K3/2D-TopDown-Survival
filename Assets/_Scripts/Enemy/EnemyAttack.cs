using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] float attackRange = 1f;
    [SerializeField] float attackCooldown = 1f;
    private HealthBar healthBar;
    [SerializeField] GameObject player;
    Animator animator;
    float timer;
    bool isAttacking;
    private void Awake()
    {
        this.animator = GetComponent<Animator>();
        this.healthBar = player.GetComponent<HealthBar>();
    }
    private void OnEnable()
    {
        this.isAttacking = false;
        this.timer = 0f;
        if (this.animator != null)
        {
            this.animator.ResetTrigger("Attack");
        }
    }
    void Update()
    {
        this.StartAttack();
    }
    void StartAttack()
    {
        timer += Time.deltaTime;
        if (isAttacking) return;
        float distance = Vector2.Distance(transform.position, this.player.transform.position);
        if (distance <= attackRange && timer >= attackCooldown)
        {
            isAttacking = true;
            animator.SetTrigger("Attack");
            timer = 0;
        }
    }
    public void DealDamage()
    {
        float distance = Vector2.Distance(transform.position, this.player.transform.position);
        if (distance > attackRange) return;
        PlayerDamageReceiver playerDamage = player.GetComponent<PlayerDamageReceiver>();
        playerDamage.TakeDamage(damage);
        this.healthBar.UpdateBar();
    }
    public void EndAttack()
    {
        isAttacking = false;
    }
}
