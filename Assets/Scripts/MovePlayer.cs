using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField]
    private float speed = 20.0f;
    [SerializeField]
    private float jumpHeight = 18.0f;
    [SerializeField]
    private float rotateSpeed = 3.0f;

    Animator animator;
    private const int MAX_JUMPS = 2;

    private int jumps;
    private float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;


    CharacterController controller;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        jumps = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            jumps = 0;
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            moveDirection = transform.forward * Input.GetAxis("Vertical") * Input.GetAxis("Horizontal") * speed;


        }
        if (Input.GetKeyDown(KeyCode.Space) && jumps < MAX_JUMPS)
        {
            moveDirection.y = jumpHeight;
            jumps++;
            animator.SetTrigger("Jump");
        }
        Debug.Log("Jumps: " + jumps);
        moveDirection.y -= gravity * Time.deltaTime;

        //controller.Move(moveDirection * Time.deltaTime);
        rb.AddForce(moveDirection);

        //transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        // TODO get rotation from mouse
        transform.Rotate(0, Input.GetAxis("Mouse X")*rotateSpeed, 0);

    }
}
