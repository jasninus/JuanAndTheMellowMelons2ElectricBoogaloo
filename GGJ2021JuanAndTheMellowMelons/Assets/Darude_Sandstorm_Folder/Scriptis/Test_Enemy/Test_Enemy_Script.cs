using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Test_Enemy_Script : MonoBehaviour, IDamageable
{
    public bool IsInRange = false;
    [SerializeField] private float Health = 40;
    
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
        Debug.Log("hit");
        
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
