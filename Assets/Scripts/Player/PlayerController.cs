using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
       [SerializeField] Camera cam;
       [SerializeField] Rigidbody rb;
       [SerializeField] float mouseSensitivity = 1;
       [SerializeField] float moveSpeed = 10;
       [SerializeField] float jumpForce = 10;

        float xRotation = 0f;

       private void Awake() 
       {
          Cursor.lockState = CursorLockMode.Locked;
          Cursor.visible = false;
       }

       private void Update() 
       {
          var rotationAmount = new Vector3(0, 1, 0) * Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
          gameObject.transform.Rotate(rotationAmount, Space.Self);

          float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
          xRotation -= mouseY;
          xRotation = Mathf.Clamp(xRotation, -80f, 80f);

          cam.gameObject.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


          var horizontalMovement = new Vector3(1, 0, 0) * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
          gameObject.transform.localPosition = horizontalMovement;

       }
}
