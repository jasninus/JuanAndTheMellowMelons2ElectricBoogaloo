using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBobbing : MonoBehaviour
{
    private float timer = 0.0f;
    [SerializeField] private float mindPoint = 1.0f;
    public float bobbingSpeed = 0.2f;
    [SerializeField] private float bobbingAmount = 0.08f;
    
    // Update is called once per frame
    void Update()
    {
        float bob = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
        {
            timer = 0.0f;
        }
        else
        {
            bob = Mathf.Sin(timer);
            timer = timer + bobbingSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }
        }
        if (bob != 0)
        {
            float translationChange = bob * bobbingAmount;
            float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            translationChange = totalAxes * translationChange;
            transform.localPosition = new Vector3(transform.localPosition.x, mindPoint + translationChange, transform.localPosition.z);
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, mindPoint, transform.localPosition.z);
        }
    }
}
