using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class BurningBook : MonoBehaviour, IActivatable
{
    [SerializeField] private int spellIndex;

    private Animator anim;

    public UnityAction onActivated;

    private bool activated;

    private static uint booksCollected;

    private void Awake()
    {
        SceneManager.sceneLoaded += ResetBooksCollected;
        anim = GetComponent<Animator>();
    }

    public void Activate()
    {
        anim.SetTrigger("Burning");

        if (booksCollected >= 6)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activated)
        {
            onActivated?.Invoke();
            Debug.Log("Invoked onActivated");
            activated = true;
            booksCollected++;

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

    private void ResetBooksCollected(Scene scene, LoadSceneMode loadMode)
    {
        booksCollected = 0;
    }

    public void AddToCallback(UnityAction method)
    {
        onActivated += method;
    }
}