using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    
    private CapsuleCollider playerCapsule;
    private float OriginalHeight;
    [SerializeField] private float crouchedHeight;

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
        if (Input.GetKeyDown(KeyCode.LeftControl)) { Crouch(); }
        else if (Input.GetKeyUp(KeyCode.LeftControl)) { stopCrouch(); }
    }
}
