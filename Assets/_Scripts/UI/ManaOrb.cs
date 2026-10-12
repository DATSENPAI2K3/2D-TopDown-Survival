using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaOrb : MonoBehaviour
{
    [SerializeField] int manaValue = 10;
    private bool isCollected = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isCollected) return;
        if (collision.CompareTag("Player"))
        {
            this.isCollected = true;
            ManaSystem manaSystem = collision.GetComponent<ManaSystem>();
            manaSystem.AddMana(this.manaValue);
            Destroy(gameObject);
        }
    }
}
