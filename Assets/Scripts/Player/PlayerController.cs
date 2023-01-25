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


       public float floatThing = 1f;
       
       [SerializeField] GameObject gameObject;

        float xRotation = 0f;

       private void Awake() 
       {
         Camera cam = FindObjectOfType<Camera>();
          Cursor.lockState = CursorLockMode.Locked;
          Cursor.visible = false;
       }

       private void Update() 
       {
          var rotationAmount = new Vector3(0, 1, 0) * Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
          gameObject.transform.Rotate(rotationAmount, Space.Self);

          float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
          xRotation -= mouseY;
          Debug.Log(Time.deltaTime);
          Debug.Log("MouseY is: " + mouseY + "xRotation is: " + xRotation);
          xRotation = Mathf.Clamp(xRotation, -80f, 80f);

          cam.gameObject.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

          float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
          float verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

          Vector3 translation = new Vector3(horizontalMovement, 0f, verticalMovement);
          transform.Translate(translation);
       }


}
