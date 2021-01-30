using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    [SerializeField] private ManaPool mana;

    [SerializeField] private Transform projectileSpellSpawn;

    public float Mana => mana.Mana;

    // Shallow copy, so not protected
    public Transform ProjectileSpellSpawn => projectileSpellSpawn;
    
    private Spell selectedSpell;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selectedSpell?.TryCast(this, 0);
        }
    }

    public void SetSpell(Spell spell)
    {
        selectedSpell = spell;
    }
}
