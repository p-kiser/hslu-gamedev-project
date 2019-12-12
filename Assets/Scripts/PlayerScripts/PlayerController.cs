using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    Rigidbody rb;
    Animator anim;

    // Serialized Fields
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


    private int MAX_JUMPS = 2;

    // private variables
    private int jumps = 2;
    
    private Vector3 moveDirection = Vector3.zero;
    private bool running;

    // player stats

    int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        // Get Components
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Reset jumps if grounded
        if (IsGrounded()) jumps = 0;

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && ++jumps < MAX_JUMPS) Jump();

        // Check if we are running
        running = Input.GetKey(KeyCode.LeftShift) /*&& IsGrounded()*/;
        
        // Calculate movement direction from inputs
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
    }

    // Everything to do with Rigidbody should be done here
    void FixedUpdate()
    {
        // Dash
        if (Input.GetKeyDown(KeyCode.Tab)) Dash();

        // Apply rotation using mouse x value
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);

        // Appy movement to player
        moveDirection = moveDirection * speed * (running ? runningMultiplikator : 1);
        //rb.MovePosition(rb.position + moveDirection * Time.fixedDeltaTime);
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
        Debug.Log("Dash");

        // even more advanced mathemagical calculations
        float x = Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime;
        float y = 0.0f;
        float z = Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime;
        Vector3 dashVelocity = Vector3.Scale(transform.forward, dashDistance * new Vector3(x, y, z));
        rb.AddForce(dashVelocity, ForceMode.VelocityChange);
    }
}
