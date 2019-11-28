using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public int moveSpeed;
    public int jumpVelocity;
    public float sensitivity;
    public float limitY;

    private float rotationY;
    private float rotationX;
    private float distToGround;

    void Start()
    {

        Collider collider = GetComponent<Collider>();
        Cursor.lockState = CursorLockMode.Locked;
        distToGround = collider.bounds.extents.y;
    }

    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        Vector3 MovementDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        MovementDirection = Camera.main.transform.TransformDirection(MovementDirection);
        MovementDirection.y = 0.0f;
        rb.transform.position += MovementDirection * moveSpeed * Time.deltaTime;

        rotationX = Camera.main.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
        rotationY += Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, -limitY, limitY);
        Camera.main.transform.localEulerAngles = new Vector3(-rotationY, 0f, 0f);
        rb.transform.localEulerAngles += new Vector3(0f, rotationX, 0f);

        if (Input.GetButtonDown("Jump") && grounded())
        {
            rb.velocity = new Vector3(0, jumpVelocity, 0);
        }
    }

    bool grounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
