using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public class Range_Attack : Enemy_Base_Attack
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Transform AttackPosition;
    [SerializeField] private float projectileSpeed = 15;
    
    public Range_Attack(float damage) : base(damage)
    {
        damage = 20.0f;
    }

    public override IEnumerator Attack()
    {
        yield return new WaitForSeconds(1.0f);
        Projectile projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.Shoot(-projectile.transform.forward * projectileSpeed);
        StartCoroutine(Attack());
    }
}
