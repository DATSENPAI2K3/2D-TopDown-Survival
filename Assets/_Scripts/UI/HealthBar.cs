using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    //public TextMeshProUGUI valueText;
    private Damageable Damageable;
    private void Awake()
    {
        this.Damageable = GetComponent<Damageable>();
    }
    private void Start()
    {
        this.UpdateBar();
    }
    public void UpdateBar()
    {
        this.fillBar.fillAmount = (float)this.Damageable.currentHp / (float)this.Damageable.maxHp;
        //this.valueText.text = (this.Damageable.currentHp * 10).ToString() + "/" + (this.Damageable.maxHp * 10).ToString();
    }
}
