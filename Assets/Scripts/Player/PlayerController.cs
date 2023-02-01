using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
       [SerializeField] GameObject cam;
       [SerializeField] Rigidbody rb;
       [SerializeField] float mouseSensitivity = 1;
       [SerializeField] float moveSpeed = 10;
       [SerializeField] float jumpForce = 10;

       
       public bool controlsActive = true;
       public bool interactableAvailable = false;

       private bool interacting = false;

       private Note currentInteractable;

       float xRotation = 0f;
       float yRotation = 0f;

       float verticalMovement;
       float horizontalMovement;

       private void Awake() 
       {
          Cursor.visible = false;
          Cursor.lockState = CursorLockMode.Locked;
       }

       private void Update() 
       {
         if (controlsActive)
         {
            float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
            
            yRotation += mouseX;
            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            transform.rotation = Quaternion.Euler(0, yRotation, 0);

            horizontalMovement = Input.GetAxisRaw("Horizontal");
            verticalMovement = Input.GetAxisRaw("Vertical");
         }


         if (interactableAvailable)
         {
            if (Input.GetKeyDown(KeyCode.E))
            {
               currentInteractable.Display();
               interacting = true;
            }
         }
         else
         {
            currentInteractable = null;
         }

         if (interacting)
         {
            controlsActive = false;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
               interacting = false;
               controlsActive = true;
               currentInteractable.UnDisplay();
            }
         }
       }


       private void FixedUpdate() 
       {
          rb.AddForce((gameObject.transform.forward * moveSpeed * verticalMovement) + gameObject.transform.right * moveSpeed * horizontalMovement, ForceMode.Force);

          Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
          if(flatVelocity.magnitude > moveSpeed)
          {
            Vector3 cappedVelocity = flatVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3 (cappedVelocity.x, 0f, cappedVelocity.z);
          }
       }


       public void SetInteractable(Note interactable)
       {
         currentInteractable = interactable;
       }

}
