using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Test_Enemy_Bilboarding : MonoBehaviour
{

    [SerializeField] private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(_camera.transform);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
