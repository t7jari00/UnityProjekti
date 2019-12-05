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
    private Vector3 velocity;

    void Start()
    {
        Collider collider = GetComponent<Collider>();
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        distToGround = collider.bounds.extents.y;
    }

    void Update()
    {
        Vector3 MovementDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        MovementDirection = transform.TransformDirection(MovementDirection);
        Vector3 moveDirecton = MovementDirection * moveSpeed;
        velocity = new Vector3(moveDirecton.x, velocity.y, moveDirecton.z);
        if (Grounded())
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y -= 25f * Time.deltaTime;
        }

        rotationX = Camera.main.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
        rotationY += Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, -limitY, limitY);
        Camera.main.transform.localEulerAngles = new Vector3(-rotationY, 0f, 0f);
        transform.localEulerAngles += new Vector3(0f, rotationX, 0f);

        if (Input.GetButtonDown("Jump") && Grounded())
        {
            velocity.y = jumpVelocity;
        }
        controller.Move(velocity * Time.deltaTime);

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
    

    private bool Grounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
