using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour, IDamageable, IHealable
{
    [SerializeField] private float startingHealth = 100;
    private float health;

    public float HealthPercentage => health / startingHealth;

    private bool invulnerable;
    public bool Invulnerable
    {
        get => invulnerable;
        set => invulnerable = value;
    }

    private void Awake()
    {
        health = startingHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            UnlockedSpells.AddSpell<FireballSpell>();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            UnlockedSpells.AddSpell<HasteSpell>();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            UnlockedSpells.AddSpell<HealSpell>();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            UnlockedSpells.AddSpell<MoonBeamSpell>();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            UnlockedSpells.AddSpell<ShieldSpell>();
		}
		
        if (Input.GetKeyDown(KeyCode.P))
        {
            UnlockedSpells.AddSpell<PoisionBallSpell>();
        }
    }

    public void TakeDamage(float damage)
    {
        if (invulnerable)
        {
            return;
        }

        health -= damage;

        Debug.Log($"Dummy player took {damage} damage");

        if (health <= 0)
        {
            Debug.Log("Dummy player is ded");
        }
    }

    public void Heal(float amount)
    {
        health += amount;

        Debug.Log($"Dummy player got healed by {amount}");
    }


}
