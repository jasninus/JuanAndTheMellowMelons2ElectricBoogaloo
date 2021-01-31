using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private string playerTag;
    private PlayerCore player;

    [SerializeField] private Image filledImage;

    private void Awake()
    {
        player = GameObject.FindWithTag(playerTag).GetComponent<PlayerCore>();
    }

    private void Update()
    {
        filledImage.fillAmount = player.HealthPercentage;
    }
}
