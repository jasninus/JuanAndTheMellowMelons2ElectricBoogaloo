using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBWithCallbacks : MonoBehaviour
{
    public delegate void MBCallback(MBWithCallbacks calledFrom);
    public MBCallback onDestroy;

    private void OnDestroy()
    {
        onDestroy?.Invoke(this);
    }
}
