using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisionBallTravel : MonoBehaviour
{
    [SerializeField] private float speed;
    
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, PlayerAiming.AimerPos(), step);
    }
}
