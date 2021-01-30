using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Cinemachine;

public class Enable : MonoBehaviour
{
    public GameObject obj;
    public AudioSource sfx;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (obj != null)
            {
                if (!obj.activeSelf)
                {
                    obj.SetActive(true);
                    sfx.Play();
                }
                else
                {
                    obj.SetActive(false);
                    sfx.Stop();
                }
            }
        }
    }


}
