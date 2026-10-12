using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float Speed = 3f;
    [SerializeField] float maxDistance = 50f;
    [SerializeField] float attackRange = 1f;
    float distance;
    SpriteRenderer spriteRenderer;
    Animator animator;
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        //this.player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        if (this.player == null)
        {
            this.animator.SetBool("isMoving", false);
            return;
        }
        this.FollowPlayer();
        this.DisableIfTooFar();
        this.HandleMovement();
    }
    void FollowPlayer()
    {
        this.distance = Vector2.Distance(transform.position, this.player.transform.position);
        if(this.distance >= attackRange)
        {
            this.animator.SetBool("isMoving", true);
            Vector2 dir = (player.transform.position - transform.position).normalized;
            transform.position += (Vector3)(dir * Speed * Time.deltaTime);
        }
        else this.animator.SetBool("isMoving", false);
    }
    void DisableIfTooFar()
    {
        if (player == null) return;
        if (Vector2.Distance(player.transform.position, transform.position) > this.maxDistance)
        {
            gameObject.SetActive(false);
        }
    }
    void HandleMovement()
    {
        if(transform.position.x > this.player.transform.position.x) spriteRenderer.flipX = true;
        else if(transform.position.x < this.player.transform.position.x) spriteRenderer.flipX = false;
    }
}
