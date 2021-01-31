using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpell : Spell
{
    [SerializeField] private float duration;
    [SerializeField] private GameObject VFX;
    private GameObject VFXInstance;

    private PlayerCore player;

    protected override void Cast(SpellCaster caster, float power)
    {
        player = caster.GetComponent<PlayerCore>();
        player.Invulnerable = true;
        StartCoroutine(DisablingShield());
        VFXInstance = Instantiate(VFX, caster.transform.position, caster.transform.rotation, caster.transform);
    }

    private IEnumerator DisablingShield()
    {
        yield return new WaitForSeconds(duration);
        player.Invulnerable = false;
        Destroy(VFXInstance);
    }
}