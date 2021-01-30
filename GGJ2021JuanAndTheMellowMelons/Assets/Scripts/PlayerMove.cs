using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody ridgedBody;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private bool grounded;
    [SerializeField] private float playerVelocity = 6f;
    [SerializeField] private float speedIncrement = 6f;
    [SerializeField] private float jumpForce = 12f;

    // Start is called before the first frame update

    void Start() => ridgedBody = GetComponent<Rigidbody>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) { playerVelocity += speedIncrement; }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) { playerVelocity -= speedIncrement; }

        float x = Input.GetAxisRaw("Horizontal") * playerVelocity;
        float y = Input.GetAxisRaw("Vertical") * playerVelocity;

        grounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y-1, transform.position.z), 0.4f, layerMask);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            ridgedBody.velocity = new Vector3(ridgedBody.velocity.x, jumpForce, ridgedBody.velocity.z);
        }

        Vector3 movePos = transform.right * x + transform.forward * y;
        Vector3 newMovePos = new Vector3(movePos.x, ridgedBody.velocity.y, movePos.z);
        ridgedBody.velocity = newMovePos;
    }
}
