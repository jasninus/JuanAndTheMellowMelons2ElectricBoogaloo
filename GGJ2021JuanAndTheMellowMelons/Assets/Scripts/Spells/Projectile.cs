using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Projectile : MonoBehaviour
{
    protected Rigidbody rb;
    protected Collider coll;

    protected static float globalGravity = -9.81f;
    protected bool usingGravity = false;
    protected float gravityScale;

    protected bool usingCollisionTagWhitelist = false;
    protected string[] collisionTagWhitelist;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        coll = GetComponent<Collider>();
    }

    public void Shoot(Vector3 velocity)
    {
        rb.velocity = velocity;
    }

    public void Shoot(Vector3 velocity, float gravityScale)
    {
        Shoot(velocity);
        usingGravity = true;
    }

    private void FixedUpdate()
    {
        Vector3 gravity = gravityScale * Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }

    public void SetColliderType(bool isTrigger)
    {
        coll.isTrigger = isTrigger;
    }

    public void SetCollisionTagWhitelist(string[] tags)
    {
        usingCollisionTagWhitelist = true;
        collisionTagWhitelist = tags;
    }

    public void DisableCollisionTagWhitelist()
    {
        usingCollisionTagWhitelist = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (usingCollisionTagWhitelist)
        {
            if (collisionTagWhitelist.Contains(other.gameObject.tag))
            {
                OnColliderHit(other);
            }
        }
        else
        {
            OnColliderHit(other);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (usingCollisionTagWhitelist)
        {
            if (collisionTagWhitelist.Contains(other.gameObject.tag))
            {
                OnTriggerHit(other);
            }
        }
        else
        {
            OnTriggerHit(other);
        }
    }

    protected virtual void OnColliderHit(Collision other)
    {
    }

    protected virtual void OnTriggerHit(Collider other)
    {
    }
}