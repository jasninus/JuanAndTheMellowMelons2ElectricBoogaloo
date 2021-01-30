using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPool : MonoBehaviour
{
    [SerializeField] private float startingMana, maxMana, manaRegen;
    private float mana;

    public float Mana => mana;

    private void Update()
    {
        mana = Mathf.Min(maxMana, mana + manaRegen * Time.deltaTime);
    }

}
