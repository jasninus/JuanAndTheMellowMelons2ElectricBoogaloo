using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float mouseSensitivity = 1000f;
    private float x = 0f;
    private float y = 0f;


    // Start is called before the first frame update
    void Start() => Cursor.lockState = CursorLockMode.Locked;

    // Update is called once per frame
    void Update()
    {
        x += -Input.GetAxis("Mouse Y") * mouseSensitivity;
        y += Input.GetAxis("Mouse X") * mouseSensitivity;
        x = Mathf.Clamp(x, -90, 90);

        transform.localRotation = Quaternion.Euler(x, 0, 0);
        player.transform.localRotation = Quaternion.Euler(0, y, 0);

        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            if (Cursor.lockState == CursorLockMode.Locked) 
            { 
                Cursor.lockState = CursorLockMode.None; 
            } 
        }
        
            
    }
}
