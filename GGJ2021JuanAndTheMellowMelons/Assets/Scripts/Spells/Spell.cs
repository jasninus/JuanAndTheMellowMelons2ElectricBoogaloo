using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    [SerializeField] protected float manaCost, upcastCost, cooldown;
    private float remainingCooldown, cooldownReductionModifier = 1;
    public float CooldownPercentage => 1 - remainingCooldown / cooldown;

    [SerializeField] private Sprite icon;
    public Sprite Icon => icon;

    public float CooldownReductionModifier
    {
        get => cooldownReductionModifier;
        set => cooldownReductionModifier = value;
    }

    public void TryCast(SpellCaster caster, float power)
    {
        if (remainingCooldown <= 0 && caster.Mana >= GetManaCost(power))
        {
            Cast(caster, power);
            remainingCooldown = cooldown;
        }
    }

    protected void Update()
    {
        remainingCooldown -= Time.deltaTime * cooldownReductionModifier;
        Debug.Log("Decreasing cooldown");
    }

    protected virtual float GetManaCost(float power) => manaCost + upcastCost * power;

    protected abstract void Cast(SpellCaster caster, float power);
}