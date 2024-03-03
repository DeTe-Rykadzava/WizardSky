using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
   public class FollowerScript : MonoBehaviour
   {
       [SerializeField] private Transform target;
       [SerializeField] private Transform source;

       [SerializeField] private float minDistance = 2f;
       [SerializeField] private float maxDistance = 2f;
       [SerializeField] private float distance = 2f;
       public float mouseSens = 1f;
       public Vector3 offset;
   
       public float verticalAngleLimit = 80f; // Limit vertical rotation to -80 to +80 degrees

       private float verticalRotation = 0f;

       private AMouseInput _mouseInput = InputManager.CurrentMouseInput;
       
       void LateUpdate()
       {
           _mouseInput.Update();
           
           if (target == null || source == null)
           {
               Debug.LogError("Target or source is not assigned.");
               return;
           }

           float mouseX = _mouseInput.MouseX * mouseSens ;
           float mouseY = _mouseInput.MouseY * mouseSens ;

           distance += _mouseInput.MouseWheel;

           distance = Mathf.Clamp(distance, minDistance, maxDistance);

           verticalRotation -= mouseY;
           verticalRotation = Mathf.Clamp(verticalRotation, -verticalAngleLimit, verticalAngleLimit);

           Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0) ;
           Debug.Log("Rotation EulerAngels: \t" + rotation.eulerAngles);
           offset = rotation * offset;

           Vector3 desiredPosition = target.position + offset * distance;

           source.position = desiredPosition;
           source.LookAt(target.position);
       }
   }
