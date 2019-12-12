using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    Rigidbody rb;
    Animator anim;
    PlayerStatus st;

    // Serialized Fields for maximum tweakability
    [SerializeField]
    private float speed = 8.0f;
    [SerializeField]
    private float jumpHeight = 2.0f;
    [SerializeField]
    private float rotateSpeed = 3.0f;
    [SerializeField]
    private float dashDistance = 10.0f;
    [SerializeField]
    private float runningMultiplikator = 3.0f;

    //Vector3 startPosition = new Vector3(-510, 52, 0);
    Vector3 startPosition = new Vector3(-132, -20, 0);

    // constanst
    private int MAX_JUMPS = 2;
    private int jumps = 2;
    private Vector3 moveDirection = Vector3.zero;
    private bool running;

    // Start is called before the first frame update
    void Start()
    {
        // Get Components
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        st = GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded()) jumps = 0;

        // Check Inputs
        running = Input.GetKey(KeyCode.LeftShift);
        
        // Calculate movement direction
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && ++jumps < MAX_JUMPS) Jump();
    }

    // Everything to do with Rigidbody should be done here
    void FixedUpdate()
    {
        // Dash
        if (Input.GetKeyDown(KeyCode.Tab)) Dash();

        // Apply rotation using mouse x value
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);

        // Appy movement to player
        moveDirection = moveDirection * speed * (running ? runningMultiplikator : 1) * st.GetSpeedMultiplicator();
        rb.AddForce(moveDirection * Time.fixedDeltaTime * 30, ForceMode.Impulse);

    }


    private bool IsGrounded()
    {
        // raycast down to detect ground
        return Physics.Raycast(transform.position, Vector3.down, out _, 1f);
    }

    private void Jump() {
        Debug.Log("Jumps: " + jumps);

        // advanced mathemagics:
        float y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
        rb.AddForce(Vector3.up * y, ForceMode.VelocityChange);
        anim.Play("Jump");
    }

    private void Dash() {
        
        float x = Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime;
        float y = 0.0f;
        float z = x;

        Vector3 dashVelocity = Vector3.Scale(transform.forward, dashDistance * new Vector3(x, y, z));
        rb.AddForce(dashVelocity, ForceMode.VelocityChange);
    }
}
