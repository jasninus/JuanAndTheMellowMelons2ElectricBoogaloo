using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy_Base_Attack : MonoBehaviour
{
    [SerializeField] protected float damage;
    [SerializeField] protected Transform targetLocation;

    protected Enemy_Base_Attack(float damage)
    {
        this.damage = damage;
        targetLocation = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public abstract IEnumerator Attack();

}
