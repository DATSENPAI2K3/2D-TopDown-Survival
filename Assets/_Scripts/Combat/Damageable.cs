using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] public int maxHp = 10;
    [SerializeField] public int currentHp;
    private void OnEnable()
    {
        this.currentHp = this.maxHp;
    }
    public virtual void TakeDamage(int dmg)
    {
        this.currentHp -= dmg;
        if (this.IsDead())
        {
            this.OnDead();
        }
    }
    public bool IsDead()
    {
        return currentHp <= 0;
    }
    protected virtual void OnDead() { }
}
