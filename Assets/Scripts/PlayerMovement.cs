using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    const float DEFAULT_SPEED = 5f;
    const float DEFAULT_JUMP = 1.5f;
    const float DEFAULT_GRAVITY = -9.81;

    private float playerSpeed;
    private float jumpHeight;
    private float gravity;

    [SerializeField] private Transform cam;

    private float turnSmoothTime = 0.1f;
    private float turnSmoothVel;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool grounded;

    public InputAction moveAction;
    public InputAction jumpAction;

    private PlayerState state;

    // Adds controller when program starts
    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        setDefaultEvo();

        controller = gameObject.AddComponent<CharacterController>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        state = new PlayerState(GlobalVars.Evolutions.defaultEvo);
        PlayerManager.instance.setPlayerState(state);
    }

    private void OnEnable() 
    {
        moveAction.Enable();
        jumpAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = controller.isGrounded;
        if (grounded && playerVelocity.y < 0) 
        {
            playerVelocity.y = 0f;
        }

        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y).normalized;
        
        if (move.magnitude >= 0.1f) {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            move = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }

        if (jumpAction.triggered && grounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        playerVelocity.y += gravity * Time.deltaTime;

        Vector3 finalMove = (move.normalized * playerSpeed) + (playerVelocity.y * Vector3.up);
        controller.Move(finalMove * Time.deltaTime);
    }

    public void changeEvo(GlobalVars.Evolutions evo) {
        setDefaultEvo();

        switch (evo) {
            case GlobalVars.Evolutions.evo1:
                playerSpeed *= 1.5;
                break;
            case GlobalVars.Evolutions.evo2:
                jumpHeight *= 1.5;
                break;
            case GlobalVars.Evolutions.evo3:
                gravity /= 1.5;
                break;
        }
    }

    private void setDefaultEvo() {
        playerSpeed = DEFAULT_SPEED;
        jumpHeight = DEFAULT_JUMP;
        gravity = DEFAULT_GRAVITY;
    }
}
