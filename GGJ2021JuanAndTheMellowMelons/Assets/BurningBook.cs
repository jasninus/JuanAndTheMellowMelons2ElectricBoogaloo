using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class BurningBook : MonoBehaviour, IActivatable
{
    private Animator anim;

    public UnityAction onActivated;

    private bool activated;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Activate()
    {
        anim.SetTrigger("Burning");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activated)
        {
            onActivated?.Invoke();
            Debug.Log("Invoked onActivated");
            activated = true;
        }
    }

    public void AddToCallback(UnityAction method)
    {
        onActivated += method;
    }
}
