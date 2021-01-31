using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnShield : MonoBehaviour
{
    public GameObject shieldVFX;
    public Vector3 shieldOffset;
    //public AudioSource audioData;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var vfx = Instantiate(shieldVFX, transform) as GameObject;
            vfx.transform.position += shieldOffset;
            //audioData = GetComponent<AudioSource>();
            //audioData.Play(0);
            Destroy(vfx, 8.5f);
        }        
    }
}
