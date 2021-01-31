using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    
    private CapsuleCollider playerCapsule;
    private float OriginalHeight;
    [SerializeField] private float crouchedHeight;
    [SerializeField] private AudioSource audiosTrack;
    [SerializeField] private AudioClip[] sfx;
    private int crouchedSfxTrigger = 0;
    private bool crouchState = false;

    // Start is called before the first frame update
    void Start()
    {
        playerCapsule = GetComponent<CapsuleCollider>();
        OriginalHeight = playerCapsule.height;
    }

    void Crouch() => playerCapsule.height = crouchedHeight;
    void stopCrouch() => playerCapsule.height = OriginalHeight;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) 
        {
            crouchState = true;
            Crouch();
            if (crouchState && crouchedSfxTrigger == 0)
            {
                crouchedSfxTrigger = 1;
                StartCoroutine(PlayerSFX.StartSFX(0.2f, 1, audiosTrack, sfx[0]));
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl)) 
        {
            crouchState = false;
            stopCrouch();
            if (!crouchState && crouchedSfxTrigger == 1)
            {
                crouchedSfxTrigger = 0;
                StartCoroutine(PlayerSFX.StartSFX(0.2f, 1, audiosTrack, sfx[0]));
            }
        }
    }
}
