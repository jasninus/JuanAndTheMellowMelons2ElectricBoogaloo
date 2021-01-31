using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rigidBody;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private AudioSource audiosTrack;
    [SerializeField] private AudioClip[] sfx;
    [SerializeField] private bool grounded;
    [SerializeField] private float baseMoveSpeed = 6f, baseSprintSpeedIncrease = 6f, jumpForce = 12f, groundedCheckRadius = 0.4f;
    private float moveSpeed, sprintSpeedIncrease;
    private int sprintSfxTrigger = 1;
    private bool sprintState = false;

    private void Awake()
    {
        moveSpeed = baseMoveSpeed;
        sprintSpeedIncrease = baseSprintSpeedIncrease;
    }

    void Start() => rigidBody = GetComponent<Rigidbody>();

    void Update()
    {
        SprintInput();

        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float y = Input.GetAxisRaw("Vertical") * moveSpeed;

        grounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), groundedCheckRadius, layerMask);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            StartCoroutine(PlayerSFX.StartSFX(0.5f, 0, audiosTrack, sfx[0]));
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpForce, rigidBody.velocity.z);
        }

        Vector3 movePos = transform.right * x + transform.forward * y;
        Vector3 newMovePos = new Vector3(movePos.x, rigidBody.velocity.y, movePos.z);
        rigidBody.velocity = newMovePos;
    }

    /// <summary>
    /// Increases speed by a percentage of base speed
    /// </summary>
    /// <param name="percentage">The percentage of base speed to increase speed with [0, 1]</param>
    public void IncreaseSpeed(float percentage)
    {
        moveSpeed += baseMoveSpeed * percentage;
        sprintSpeedIncrease += baseSprintSpeedIncrease * percentage;
    }

    /// <summary>
    /// Decreases speed by a percentage of base speed
    /// </summary>
    /// <param name="percentage">The percentage of base speed to decrease speed with [0, 1]</param>
    public void DecreaseSpeed(float percentage)
    {
        moveSpeed -= baseMoveSpeed * percentage;
        sprintSpeedIncrease -= baseSprintSpeedIncrease * percentage;
    }

    public void ResetSpeedModifier()
    {
        moveSpeed = baseMoveSpeed;
        sprintSpeedIncrease = baseSprintSpeedIncrease;
    }

    private void SprintInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            sprintState = true;
            moveSpeed += sprintSpeedIncrease;
            if (sprintState && sprintSfxTrigger == 1)
            {
                sprintSfxTrigger = 0;
                StartCoroutine(PlayerSFX.StartSFX(0.3f, 1, audiosTrack, sfx[1]));
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            sprintState = false;
            moveSpeed -= sprintSpeedIncrease;
            if (!sprintState && sprintSfxTrigger == 0)
            {
                sprintSfxTrigger = 1;
                StartCoroutine(PlayerSFX.StartSFX(0.4f, 1, audiosTrack, sfx[2]));
            }
        }
    }
}
