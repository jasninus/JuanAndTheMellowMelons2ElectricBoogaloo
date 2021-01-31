using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Melee_Attack : Enemy_Base_Attack
{
    [SerializeField] private Transform weaponPosition;
    [SerializeField] private float meleeRange;
    [SerializeField] private LayerMask player;
    
    public Enemy_Melee_Attack(float damage) : base(damage)
    {
        damage = 10.0f;
    }

    public override IEnumerator Attack()
    {
        yield return new WaitForSeconds(1.0f);
        Collider[] hitPlayer = Physics.OverlapSphere(weaponPosition.position, meleeRange, player);
        foreach (Collider collider1 in hitPlayer)
        {
            Debug.Log("Player hit");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (weaponPosition == null)
            return;
        
        Gizmos.DrawWireSphere(weaponPosition.position, meleeRange);
    }
}
