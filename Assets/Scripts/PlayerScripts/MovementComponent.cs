using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{
    [SerializeField]
    float walkSpeed = 5;
    [SerializeField]
    float runSpeed = 10;
    [SerializeField]
    float jumpForce = 5;
    [SerializeField]
    private PlayerStats stats;

    // Components
    private PlayerController playerController;
    Rigidbody rigidbody;
    Animator playerAnimator;
    public GameObject followTarget;

    // References
    Vector2 inputVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;
    Vector2 lookInput = Vector2.zero;

    public float aimSensitivity = 0.01f;

    // Animator Hashes
    public readonly int movementXHash = Animator.StringToHash("MovementX");
    public readonly int movementYHash = Animator.StringToHash("MovementY");
    public readonly int isJumpingHash = Animator.StringToHash("IsJumping");
    public readonly int isRunningHash = Animator.StringToHash("IsRunning");
    public readonly int isFiringHash = Animator.StringToHash("IsFiring");
    public readonly int isRealoadingHash = Animator.StringToHash("IsReloading");
    public readonly int aimVerticalHash = Animator.StringToHash("AimVertical");

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        rigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Disable the cursor for gameplay
        if (!GameManager.instance.cursorActive)
        {
            AppEvents.InvokeOnMouseCursorEnable(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLook();
        UpdateMovement();
    }

    private void UpdateLook()
    {
        // Aiming / Looking
        // Horizontal rotation
        followTarget.transform.rotation *= Quaternion.AngleAxis(lookInput.x * aimSensitivity, Vector3.up);

        // Vertical rotation
        followTarget.transform.rotation *= Quaternion.AngleAxis(lookInput.y * aimSensitivity, Vector3.left);

        var angles = followTarget.transform.localEulerAngles;
        angles.z = 0;

        var angle = followTarget.transform.localEulerAngles.x;

        if (angle > 180 && angle < 340)
        {
            angles.x = 340;
        }
        else if (angle < 180 && angle > 40)
        {
            angles.x = 40;
        }

        followTarget.transform.localEulerAngles = angles;

        // Rotate the player rotation based on the look transform
        transform.rotation = Quaternion.Euler(0, followTarget.transform.rotation.eulerAngles.y, 0);

        followTarget.transform.localEulerAngles = new Vector3(angles.x, 0, 0);

    }

    private void UpdateMovement()
    {
        // Movement
        if (playerController.isJumping) return;
        if (!(inputVector.magnitude > 0)) moveDirection = Vector3.zero;

        moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;
        float currentSpeed = playerController.isRunning ? runSpeed : walkSpeed;

        Vector3 movementDirection = moveDirection * (stats.speedMultiplier * currentSpeed);

        rigidbody.velocity = movementDirection;
    }


    /// Input System ///

    public void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();
        playerAnimator.SetFloat(movementXHash, inputVector.x);
        playerAnimator.SetFloat(movementYHash, inputVector.y);
    }
    public void OnRun(InputValue value)
    {
        playerController.isRunning = value.isPressed;
        playerAnimator.SetBool(isRunningHash, playerController.isRunning);
    }
    public void OnJump(InputValue value)
    {
        if (playerController.isJumping)
            return;

        playerController.isJumping = value.isPressed;
        rigidbody.AddForce((transform.up + moveDirection) * jumpForce, ForceMode.Impulse);
        playerAnimator.SetBool(isJumpingHash, playerController.isJumping);
    }

    public void OnAim(InputValue value)
    {
        playerController.isAiming = value.isPressed;
    }

    public void OnLook(InputValue value)
    {
        if (playerController.isInventoryOpen) return;

        lookInput = value.Get<Vector2>();

        var angle = followTarget.transform.localEulerAngles.x;

        if (angle > 180)
        {
            angle -= 360;
        }

        float lookParameter = Mathf.InverseLerp(-20, 40, angle);
        playerAnimator.SetFloat(aimVerticalHash, lookParameter);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !playerController.isJumping) return;

        playerController.isJumping = false;
        playerAnimator.SetBool(isJumpingHash, false);
    }
}
