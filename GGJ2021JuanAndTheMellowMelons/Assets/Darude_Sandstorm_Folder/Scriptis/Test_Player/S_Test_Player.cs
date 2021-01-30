using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Test_Player : MonoBehaviour
{

    [SerializeField] private new Transform transform;
    [SerializeField] private new Camera camera;

    private float _rotationSpeed;
    private float _speed;

    private void Start()
    {
        _speed = 2;
        _rotationSpeed = 50;
    }

    void Update()
    {
        var transformPosition = transform.position;
        camera.transform.position = transformPosition;

        var horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
        var verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * _speed;
        var _camX = Input.GetAxis("Mouse X");
        var _camY = Input.GetAxis("Mouse Y");
        
        camera.transform.Rotate(0, _camX, 0);
        transform.Rotate(0, _camX, 0);
        transform.Translate(horizontalInput, 0, verticalInput);

    }
}
