using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDummy : MonoBehaviour, IDamageable
{
    [SerializeField] private float health = 100;

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
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        Debug.Log($"Dummy player took {damage} damage");

        if (health <= 0)
        {
            Debug.Log("Dummy player is ded");
        }
    }
}
