using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SpellSlot : MonoBehaviour
{
    [SerializeField] private Image filledImage;

    private Spell spell;
    public Spell Spell
    {
        get => spell;
        
        set
        {
            spell = value;
            Image = spell.Icon;
        }
    }

    private Image image;
    private Sprite Image
    {
        set
        {
            image.sprite = value;
            filledImage.sprite = value;
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
            filledImage.color = new Color(filledImage.color.r, filledImage.color.g, filledImage.color.b, 1);
        }
    }

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (spell & filledImage)
        {
            filledImage.fillAmount = spell.CooldownPercentage;
        }
    }
}