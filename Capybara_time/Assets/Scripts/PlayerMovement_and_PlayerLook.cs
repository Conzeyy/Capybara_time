using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class PlayerMovement_and_PlayerLook : MonoBehaviour {
     public float speed = 25.0F;
     public float jumpSpeed = 8.0F; 
     public float gravity = 20.0F;
     private Vector3 moveDirection = Vector3.zero;
     private float turner;
     private float looker;
     public float sensitivity = 5;
     
     // Use this for initialization
     void Start () {
         
     }
     
     // Update is called once per frame
     void Update () {
         CharacterController controller = GetComponent<CharacterController>();

         if (controller.isGrounded) {

             moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
             moveDirection = transform.TransformDirection(moveDirection);
             moveDirection *= speed;
             if (Input.GetButton("Jump"))
                 moveDirection.y = jumpSpeed;
         }
         turner = Input.GetAxis ("Mouse X")* sensitivity;
         looker = -Input.GetAxis ("Mouse Y")* sensitivity;
         if(turner != 0){
             transform.eulerAngles += new Vector3 (0,turner,0);
         }
         if(looker != 0){
             transform.eulerAngles += new Vector3 (looker,0,0);
         }
         moveDirection.y -= gravity * Time.deltaTime;
         controller.Move(moveDirection * Time.deltaTime);
     }
 }