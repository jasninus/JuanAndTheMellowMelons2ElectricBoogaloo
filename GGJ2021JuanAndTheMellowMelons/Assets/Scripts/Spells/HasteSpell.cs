using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasteSpell : Spell
{
    protected override void Cast(SpellCaster caster, float power)
    {
        Debug.Log("GOTTA GO FAST!");
    }
}
