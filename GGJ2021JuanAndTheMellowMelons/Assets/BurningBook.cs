using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class BurningBook : MonoBehaviour, IActivatable
{
    [SerializeField] private int spellIndex;

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

            switch (spellIndex)
            {
                case 0:
                    UnlockedSpells.AddSpell<FireballSpell>();
                    break;

                case 1:
                    UnlockedSpells.AddSpell<HealSpell>();
                    break;

                case 2:
                    UnlockedSpells.AddSpell<HasteSpell>();
                    break;

                case 3:
                    UnlockedSpells.AddSpell<ShieldSpell>();
                    break;

                case 4:
                    UnlockedSpells.AddSpell<MoonBeamSpell>();
                    break;

                case 5:
                    UnlockedSpells.AddSpell<PoisionBallSpell>();
                    break;

                default:
                    break;
            }
        }
    }

    public void AddToCallback(UnityAction method)
    {
        onActivated += method;
    }
}