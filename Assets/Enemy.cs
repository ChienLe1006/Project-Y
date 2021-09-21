using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Singleton<Enemy>
{
    [SerializeField] Slider healthBar;
    [SerializeField] Damageable health;

    public void TakeDamage(float ammount)
    {
        healthBar.value = health.Change(-ammount);
    }

    private void Start()
    {
        health.Refresh();
    }

    public void Heal(float ammount)
    {
        healthBar.value = health.Change(+ammount);
    }
}
