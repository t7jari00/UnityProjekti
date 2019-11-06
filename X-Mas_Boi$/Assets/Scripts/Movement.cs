using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private int moveSpeed = 5;
    private int rotateSpeed = 40;
    private float minRotation = 270;
    private float maxRotation = 45;

    public float sensitivity;
    public float limitY;

    private float rotationY;
    private float rotationX;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        Vector3 MovementDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        MovementDirection = Camera.main.transform.TransformDirection(MovementDirection);
        MovementDirection.y = 0.0f;
        rb.transform.position += MovementDirection * moveSpeed * Time.deltaTime;

        /*
        Vector3 PlayerRotation = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        rb.transform.Rotate(PlayerRotation * Time.deltaTime * rotateSpeed);

        Vector3 CameraRotation = new Vector3(-Input.GetAxis("Mouse Y"), 0, 0);
        Camera.main.transform.Rotate(CameraRotation * Time.deltaTime * rotateSpeed);

        Vector3 currentRotation = Camera.main.transform.localRotation.eulerAngles;
        currentRotation.x = Mathf.Clamp(currentRotation.x, minRotation, maxRotation);
        Camera.main.transform.localRotation = Quaternion.Euler(currentRotation);
        */

        rotationX = Camera.main.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
        rotationY += Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, -limitY, limitY);
        Camera.main.transform.localEulerAngles = new Vector3(-rotationY, 0f, 0f);
        rb.transform.localEulerAngles += new Vector3(0f, rotationX, 0f);
    }
}
