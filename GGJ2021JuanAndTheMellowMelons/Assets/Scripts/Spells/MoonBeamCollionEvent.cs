using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonBeamCollionEvent : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter(Collider other) => this.GetComponent<IDamageable>()?.TakeDamage(damage);
    private void OnTriggerExit(Collider other) => this.GetComponent<IDamageable>()?.TakeDamage(damage);

}
