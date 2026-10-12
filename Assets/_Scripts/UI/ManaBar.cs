using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [SerializeField] Image manaFillBar;
    public void ManaUpdateBar(int currentMana, int maxMana)
    {
        manaFillBar.fillAmount = (float)currentMana / (float)maxMana;
    }
}
