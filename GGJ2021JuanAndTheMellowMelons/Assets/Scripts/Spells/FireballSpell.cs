using UnityEngine;

public class FireballSpell : Spell
{
    [SerializeField] private Projectile fireballProjectile;
    [SerializeField] private float projectileSpeed;

    protected override void Cast(SpellCaster caster, float power)
    {
        Projectile fireball = Instantiate(fireballProjectile, caster.ProjectileSpellSpawn.position, caster.ProjectileSpellSpawn.rotation);
        fireball.Shoot(fireball.transform.forward * projectileSpeed);
    }
}