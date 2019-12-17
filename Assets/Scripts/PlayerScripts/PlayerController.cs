using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    // Components
    Rigidbody rb;
    Animator anim;
    PlayerStatus st;
    Camera cam;

    // sound effects
    [SerializeField]
    AudioClip jumpSound;

    // Serialized Fields for maximum tweakability

    private float speed = 6.0f;
    private float jumpHeight = 2.0f;
    private float rotateSpeed = 3.0f;
    private float dashDistance = 10.0f;
    private float runningMultiplikator = 1.5f;

    // constanst
    private int MAX_JUMPS = 2;
    private int jumps = 2;
    private float pitch;
    private Vector3 moveDirection = Vector3.zero;

    private bool running;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get Components
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        st = GetComponent<PlayerStatus>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate movement direction
        moveDirection = new Vector3(InputController.instance.GetXMovementAxis(),
                                    0, 
                                    InputController.instance.GetYMovementAxis());
        moveDirection = transform.TransformDirection(moveDirection);

        // Jumping
        if (InputController.instance.Jumping() && ++jumps < MAX_JUMPS) Jump();

        // Dash
        if (InputController.instance.Dashing()) Dash();

        if (InputController.instance.RestartKey()) GameController.instance.RestartGame();

    }

    // Everything to do with Rigidbody should be done here
    void FixedUpdate()
    {
        // Check if is grounded
        if (IsGrounded())
        {
            jumps = 0;
            running = InputController.instance.Running();
        }

        // Apply rotation using mouse X axis value
        transform.Rotate(0, 
                         InputController.instance.GetXRotationAxis() * rotateSpeed, 
                         0);

        // Pitch camera according to mouse Y axis value
        pitch -= InputController.instance.GetYRotationAxis();
        cam.transform.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);




        // Apply movement to player
        moveDirection = moveDirection * speed * (running ? runningMultiplikator : 1) * st.GetSpeedMultiplicator();
        rb.AddForce(moveDirection * Time.fixedDeltaTime * 30, ForceMode.Impulse);

    }


    private bool IsGrounded()
    {
        // raycast down to detect ground
        return Physics.Raycast(transform.position, Vector3.down, out _, 1f);
    }

    private void Jump() {
        // advanced mathemagics:
        float y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
        rb.AddForce(Vector3.up * y, ForceMode.VelocityChange);

        PlaySound(jumpSound);
        anim.Play("Jump");
    }

    private void Dash() {
        
        float x = Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime;
        float y = 0.0f;
        float z = x;

        Vector3 dashVelocity = Vector3.Scale(transform.forward, dashDistance * new Vector3(x, y, z));
        rb.AddForce(dashVelocity, ForceMode.VelocityChange);
    }

    private void PlaySound(AudioClip clip) {
        AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);
    }
}
