using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpell : Spell
{
    [SerializeField] private float healAmount;

    protected override void Cast(SpellCaster caster, float power)
    {
        IHealable healable = caster.GetComponent<IHealable>();
        healable?.Heal(healAmount);
    }
}
