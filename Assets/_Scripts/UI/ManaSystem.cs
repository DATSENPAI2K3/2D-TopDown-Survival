using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaSystem : MonoBehaviour
{
    [SerializeField] int currentMana = 0;
    [SerializeField] int maxMana = 100;
    [SerializeField] ManaBar ManaBar;
    [SerializeField] GameObject extraGunR2;
    [SerializeField] GameObject extraGunR3;
    int resetMana = 0;
    private void Start()
    {
        if (extraGunR2 != null) extraGunR2.SetActive(false);
        if (extraGunR3 != null) extraGunR3.SetActive(false);
        this.ManaBar.ManaUpdateBar(currentMana, maxMana);
    }
    public void AddMana(int amount)
    {
        this.currentMana += amount;
        if (this.currentMana >= maxMana)
        {
            if(resetMana >= 2)
            {
                this.currentMana = maxMana;
                this.ManaBar.ManaUpdateBar(currentMana, maxMana);
                return;
            }
            if(resetMana == 0)
            {
                this.extraGunR2.SetActive(true);
                this.resetMana++;
            }
            else if (resetMana == 1)
            {
                this.extraGunR3.SetActive(true);
                this.resetMana++;
            }
            this.currentMana = 0;
        }
        this.ManaBar.ManaUpdateBar(currentMana, maxMana);
    }
}
