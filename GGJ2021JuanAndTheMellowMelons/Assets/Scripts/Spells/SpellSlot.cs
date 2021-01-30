using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSlot : MonoBehaviour
{
    private Spell spell;

    public Spell Spell
    {
        get => spell;
        set => spell = value;
    }
}
