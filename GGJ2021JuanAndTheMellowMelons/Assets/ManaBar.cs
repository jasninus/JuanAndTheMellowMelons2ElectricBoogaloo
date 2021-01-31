using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [SerializeField] private string playerTag;
    private ManaPool mana;

    [SerializeField] private Image filledImage;

    private void Awake()
    {
        mana = GameObject.FindWithTag(playerTag).GetComponent<ManaPool>();
    }

    private void Update()
    {
        filledImage.fillAmount = mana.ManaPercentage;
    }
}