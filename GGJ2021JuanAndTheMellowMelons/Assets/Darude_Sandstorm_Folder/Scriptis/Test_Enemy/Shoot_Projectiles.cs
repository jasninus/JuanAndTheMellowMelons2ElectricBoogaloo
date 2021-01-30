using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Projectiles : MonoBehaviour
{
    [SerializeField] private Projectile projectile;
    [SerializeField] private float projectileSpeed = 15;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private Transform targetTransform;
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    public IEnumerator Shooting()
    {
        yield return new WaitForSeconds(1.0f);
        projectile = Instantiate(projectile, Enemy.transform.position, Enemy.transform.rotation);
        projectile.Shoot(-projectile.transform.forward * projectileSpeed);
    }
    
}
