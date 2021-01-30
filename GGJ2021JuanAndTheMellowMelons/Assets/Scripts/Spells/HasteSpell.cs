using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasteSpell : Spell
{
    [SerializeField] private float speedIncreaseDuration, spellCooldownReductionDuration, speedIncrease, hasteCooldownReductionModifier;

    protected override void Cast(SpellCaster caster, float power)
    {
        PlayerMove movement = caster.GetComponent<PlayerMove>();

        StopAllCoroutines();
        ResetSpellCooldownModifiers();
        ResetSpeedIncrease(movement);

        IncreaseMovementSpeed(movement);
        ReduceSpellCooldowns();

        Debug.Log("Gotta go fast");
    }

    private void ReduceSpellCooldowns()
    {
        foreach (Spell spell in UnlockedSpells.GetUnlockedSpells())
        {
            spell.CooldownReductionModifier = hasteCooldownReductionModifier;
        }

        StartCoroutine(ResettingSpellCooldownModifiers());
    }

    private IEnumerator ResettingSpellCooldownModifiers()
    {
        yield return new WaitForSeconds(spellCooldownReductionDuration);
        ResetSpellCooldownModifiers();
    }

    private void ResetSpellCooldownModifiers()
    {
        foreach (Spell spell in UnlockedSpells.GetUnlockedSpells())
        {
            spell.CooldownReductionModifier = 1;
        }
    }

    private void IncreaseMovementSpeed(PlayerMove movement)
    {
        movement.IncreaseSpeed(speedIncrease);
        StartCoroutine(DecreasingSpeed(movement));
    }

    private IEnumerator DecreasingSpeed(PlayerMove movement)
    {
        float startTime = Time.time, previousUpdateTime = startTime;

        while (Time.time < startTime + speedIncreaseDuration)
        {
            float timeDiff = Time.time - previousUpdateTime;
            float percentage = timeDiff / speedIncreaseDuration;
            float percentageReduction = speedIncrease * percentage;
            movement.DecreaseSpeed(percentageReduction);

            previousUpdateTime = Time.time;
            yield return null;
        }

        ResetSpeedIncrease(movement);
    }

    private void ResetSpeedIncrease(PlayerMove movement)
    {
        movement?.ResetSpeedModifier();
    }
}
