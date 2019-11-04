using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField]
    private float speed = 12.0f;
    [SerializeField]
    private float jumpHeight = 18.0f;
    [SerializeField]
    private float rotateSpeed = 3.0f;

    private int jumps;
    private float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    

    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
       controller = GetComponent<CharacterController>();

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
            
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumps <= 2)
        {
            moveDirection.y = jumpHeight;
            jumps++;
        }
        Debug.Log("Jumps: " + jumps);
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);


        //transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        // TODO get rotation from mouse
        transform.Rotate(0, Input.GetAxis("Mouse X")*rotateSpeed, 0);

    }
}
