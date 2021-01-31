using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisionBallEffect : MonoBehaviour
{

    [SerializeField] private float tickIntervals;
    [SerializeField] private float tickDamage;
    [SerializeField] private float tickDuration;
    private float amountOfTicks = 0f;
    private bool infected = false;
    static public bool tickDurationFinished = false;

    private IEnumerator TickDuration()
    {
        yield return new WaitForSeconds(tickDuration);
        tickDurationFinished = true;
        Debug.Log("Ticks ended");
    }

    private IEnumerator TickDamage()
    {
        infected = false;
        yield return new WaitForSeconds(tickIntervals);
        this.GetComponent<IDamageable>()?.TakeDamage(tickDamage);
        Debug.Log("Tick");
        infected = true;
        if (amountOfTicks < 1)
        {
            Debug.Log("Tick timer started");
            StartCoroutine(TickDuration());
        }
        amountOfTicks++;
    }

    private void OnTriggerEnter(Collider other)
    {
        infected = true;
    }

    private void Update()
    {
        if (infected && !tickDurationFinished)
        {
            StartCoroutine(TickDamage()); 
        }
    }


}
