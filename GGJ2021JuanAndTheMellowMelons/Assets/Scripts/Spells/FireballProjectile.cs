using UnityEngine;

public class FireballProjectile : Projectile
{
    [SerializeField] private float explosionRadius;
    [SerializeField] private float centerDamage;
    [SerializeField] private SpawnFireballScript vfx;

    protected override void OnColliderHit(Collision other)
    {
        //if (other.gameObject.CompareTag("Enemy"))
        //{
            ApplyDamage();
            CreateSFX();
            Destroy(gameObject);
        //}
    }

    private void ApplyDamage()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider coll in colls)
        {
            IDamageable damageable = coll.GetComponent<IDamageable>();

            if (damageable != null)
            {
                float disFromCenter = Vector3.Distance(coll.transform.position, transform.position);
                float damage = centerDamage * (1 - disFromCenter / explosionRadius);
                damageable.TakeDamage(damage);
            }
        }
    }

    private void CreateSFX()
    {
        vfx.SpawnVFX();
    }
    
    
}