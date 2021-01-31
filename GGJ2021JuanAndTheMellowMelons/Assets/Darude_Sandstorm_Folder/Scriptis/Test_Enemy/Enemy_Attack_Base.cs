using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy_Attack_Base : MonoBehaviour
{
    [SerializeField] [CanBeNull] private Projectile projectilePrefab;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private LayerMask Player;
    [SerializeField] [CanBeNull] private Transform AttackPosition;
    
    [SerializeField] private float projectileSpeed = 15;
    [SerializeField] private float MeleeDamage = 20;
    [SerializeField] private float AttackRange = 0.5f;
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    public IEnumerator Shooting()
    {
        yield return new WaitForSeconds(1.0f);
        Projectile projectile = Instantiate(projectilePrefab, Enemy.transform.position, Enemy.transform.rotation);
        projectile.Shoot(-projectile.transform.forward * projectileSpeed);
        StartCoroutine(Shooting());
    }

    public IEnumerator MeleeAttack()
    {
        yield return new WaitForSeconds(1.0f);
        Collider[] hitPlayer = Physics.OverlapSphere(AttackPosition.position, AttackRange, Player);
        foreach (Collider player in hitPlayer)
        {
            Debug.Log("Player hit");
        }
    }
    
}
