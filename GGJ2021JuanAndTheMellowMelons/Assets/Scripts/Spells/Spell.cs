using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    [SerializeField] protected float manaCost, upcastCost, cooldown;
    private float lastCastTime;

    public void TryCast(SpellCaster caster, float power)
    {
        if (lastCastTime + cooldown <= Time.time && caster.Mana >= GetManaCost(power))
        {
            Cast(caster, power);
            lastCastTime = Time.time;
        }
    }

    protected virtual float GetManaCost(float power) => manaCost + upcastCost * power;

    protected abstract void Cast(SpellCaster caster, float power);
}