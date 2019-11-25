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
    private float speed = 5.0f;
    [SerializeField]
    private float jumpHeight = 2.0f;
    [SerializeField]
    private float rotateSpeed = 3.0f;
    [SerializeField]
    private float dashDistance = 10.0f;
    [SerializeField]
    private float runningMultiplikator = 3.0f;
    private bool running = false;

    // private variables
    private int jumps = 2;
    private int max_jumps = 2;
    private Vector3 moveDirection = Vector3.zero;


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
        // reset jumps if grounded
        if (IsGrounded()) jumps = 0;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            running = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            running = false;
        }

        // get movement direction from inputs
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);


    }

    // Everything to do with Rigidbody should be done here
    void FixedUpdate()
    {
        // Jump
        if (Input.GetButtonDown("Jump") && jumps < max_jumps)
        {
            jumps++;
            Debug.Log("Jumps: " + jumps);
            //rb.AddForce(Vector3.up * jumpHeight/jumps, ForceMode.Impulse);
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight/jumps * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            anim.Play("Jump");
        }

        // Dash
        // TODO: Add "dash" in config //if (Input.GetButtonDown("Dash"))
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Dash");
            Vector3 dashVelocity = Vector3.Scale(transform.forward, dashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime)));
            rb.AddForce(dashVelocity, ForceMode.VelocityChange);
        }
        // rotate using mouse position mouse
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);

        // appy movement
        moveDirection = moveDirection * speed * (running ? runningMultiplikator : 1);
        rb.MovePosition(rb.position + moveDirection * Time.fixedDeltaTime);
    }


    bool IsGrounded()
    {
        // raycast down to detect ground
        return Physics.Raycast(transform.position, Vector3.down, out _, 1f);
    }


}
