using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    const float DEFAULT_SPEED = 5f;
    const float DEFAULT_JUMP = 1.5f;
    const float DEFAULT_GRAVITY = -9.81f;

    private float playerSpeed;
    private float jumpHeight;
    private float gravity;

    private Transform cam;

    private float turnSmoothTime = 0.1f;
    private float turnSmoothVel;
    private CharacterController controller;
    public Vector3 playerVelocity;
    public bool grounded;
    public Vector3 finalMove;

    public InputAction moveAction;
    public InputAction jumpAction;

    // Adds controller when program starts
    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        setDefaultEvo();

        controller = gameObject.GetComponent<CharacterController>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
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

        finalMove = (move.normalized * playerSpeed) + (playerVelocity.y * Vector3.up);
        // if (grounded && playerVelocity.y < 0) 
        // {
        //     playerVelocity.y = 0.0f;
        // }

        
        controller.Move(finalMove * Time.deltaTime);

        bool lastGrounded = grounded;
        grounded = controller.isGrounded;
        
        // Walk off of ledge -> reset Y velocity.
        if (!grounded && lastGrounded != grounded && !jumpAction.triggered) {
            playerVelocity.y = 0.0f;
        }

        
    }

    public void changeEvo(GlobalVars.Evolutions evo) {
        setDefaultEvo();

        switch (evo) {
            case GlobalVars.Evolutions.evo1:
                playerSpeed *= 1.5f;
                break;
            case GlobalVars.Evolutions.evo2:
                jumpHeight *= 2.0f;
                break;
            case GlobalVars.Evolutions.evo3:
                gravity /= 2.5f;
                break;
        }
    }

    private void setDefaultEvo() {
        playerSpeed = DEFAULT_SPEED;
        jumpHeight = DEFAULT_JUMP;
        gravity = DEFAULT_GRAVITY;
    }
}
