using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisionBallSpell : Spell
{
    [SerializeField] private GameObject poisionBallPrefab;
    [SerializeField] private float poisionBallLifeTime;

    private IEnumerator SpawnPoisionBall(SpellCaster caster)
    {
        GameObject currentPoisionBall = Instantiate(poisionBallPrefab, caster.ProjectileSpellSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(poisionBallLifeTime);
        Destroy(currentPoisionBall);
    }

    protected override void Cast(SpellCaster caster, float power)
    {
        StartCoroutine(SpawnPoisionBall(caster));
    }



}
