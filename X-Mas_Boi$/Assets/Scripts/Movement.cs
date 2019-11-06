using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private int moveSpeed = 5;
    private int rotateSpeed = 40;

    private void Start()
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

        Vector3 PlayerRotation = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        rb.transform.Rotate(PlayerRotation * Time.deltaTime * rotateSpeed);

        Vector3 CameraRotation = new Vector3(-Input.GetAxis("Mouse Y"), 0, 0);
        Camera.main.transform.Rotate(CameraRotation * Time.deltaTime * rotateSpeed);
        if (Camera.main.transform.rotation.x > 40)
        {
            Camera.main.transform.eulerAngles = new Vector3(
                40,
                Camera.main.transform.eulerAngles.y,
                Camera.main.transform.eulerAngles.z
            );
        }
        else if (Camera.main.transform.rotation.x < -50)
        {
            Camera.main.transform.eulerAngles = new Vector3(
                -50,
                Camera.main.transform.eulerAngles.y + 180,
                Camera.main.transform.eulerAngles.z
            );
        }
    }
}
