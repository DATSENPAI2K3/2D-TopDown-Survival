using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;
    Vector2 direction;
    private void OnEnable()
    {
        Invoke("Disable", lifeTime);
    }
    private void Update()
    {
        this.Shoot();
    }
    void Disable()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    public void SetDirection(Vector2 dir)
    {
        this.direction = dir.normalized;
    }
    void Shoot()
    {
        transform.Translate(this.direction * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;
        Damageable damageable = collision.GetComponent<Damageable>();
        damageable.TakeDamage(1);
        gameObject.SetActive(false);
    }
}
