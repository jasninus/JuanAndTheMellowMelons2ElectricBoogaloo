using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Enemy_Script : MonoBehaviour, IDamageable
{

    [SerializeField] private FireballProjectile projectile;
    
    public bool IsInRange = false;
    private float Health = 40;

    void Start()
    {
        
    }

    void Update()
    {
        if (projectile.EnemyHit)
        {
            Debug.Log(Health);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsInRange = false;
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

}
