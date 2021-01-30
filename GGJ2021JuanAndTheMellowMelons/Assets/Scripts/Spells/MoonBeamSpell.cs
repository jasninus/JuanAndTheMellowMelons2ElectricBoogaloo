using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoonBeamSpell : Spell
{
    [SerializeField] private GameObject moonBeamPrefab;
    [SerializeField] private float moonBeamDuration;
    [SerializeField] private string aimerName;

    private IEnumerator SpawnMoonBeam()
    {
        GameObject currentMoonBeam = Instantiate(moonBeamPrefab, PlayerAiming.AimerPos(), Quaternion.identity);
        yield return new WaitForSeconds(moonBeamDuration);
        Destroy(currentMoonBeam);
    }

    protected override void Cast(SpellCaster caster, float power)
    {
        if (GameObject.Find(aimerName)) StartCoroutine(SpawnMoonBeam());
        else
        {
            Debug.Log("fail");
        }
    }




}
