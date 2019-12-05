using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public int moveSpeed;
    public int jumpVelocity;
    public float sensitivity;
    public float limitY;
    public float camDist;

    private float rotationY;
    private float rotationX;
    private float distToGround;
    private CharacterController controller;

    void Start()
    {
        //Collider collider = GetComponent<Collider>();
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        //distToGround = collider.bounds.extents.y;
    }

    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        /*
        Vector3 MovementDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        MovementDirection = Camera.main.transform.TransformDirection(MovementDirection);
        MovementDirection.y = 0.0f;
        rb.transform.position += MovementDirection * moveSpeed * Time.deltaTime;
        */
        Vector3 MovementDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        MovementDirection = Camera.main.transform.TransformDirection(MovementDirection);
        MovementDirection.y = 0.0f;
        Vector3 moveDirecton = MovementDirection * moveSpeed;
        Vector3 velocity = new Vector3(moveDirecton.x, 0, moveDirecton.z);
        if (controller.isGrounded)
        {
            velocity.y = 0;
        }else
        {
            velocity.y -= 25f * Time.deltaTime;
        }
        controller.Move(velocity * Time.deltaTime);

        rotationX = Camera.main.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
        rotationY += Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, -limitY, limitY);
        Camera.main.transform.localEulerAngles = new Vector3(-rotationY, 0f, 0f);
        rb.transform.localEulerAngles += new Vector3(0f, rotationX, 0f);

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            rb.velocity = new Vector3(0, jumpVelocity, 0);
        }

        RaycastHit hit;
        Vector3 direction = Camera.main.transform.position - this.transform.position;
        if (Physics.Raycast(this.transform.position, direction.normalized, out hit, camDist))
        {
            Camera.main.transform.position = hit.point;
        }
        else
        {
            Camera.main.transform.position = this.transform.position + direction.normalized * camDist;
        }
    }
    

    /*bool grounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }*/
}
