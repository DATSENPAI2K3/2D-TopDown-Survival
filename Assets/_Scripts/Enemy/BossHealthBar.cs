using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] Image fillBar;
    private Damageable damageable;
    void Start()
    {
        this.damageable = GetComponent<Damageable>();
    }
    void Update()
    {
        this.BossUpdateBar();
    }
    void BossUpdateBar()
    {
        this.fillBar.fillAmount = (float)damageable.currentHp / (float)damageable.maxHp;
    }
}
