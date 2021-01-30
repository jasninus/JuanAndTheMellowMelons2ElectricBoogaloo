using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Enemy_Script : MonoBehaviour
{
    public bool IsInRange = false;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            IsInRange = false;
        }
    }
}
