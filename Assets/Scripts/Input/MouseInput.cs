using UnityEngine;

    public class MouseInput : AMouseInput
    {
        public override void Update()
        {
            Cursor.lockState = CursorLockMode.Locked;
            MouseX = Input.GetAxis("Mouse X");
            MouseY = Input.GetAxis("Mouse Y");
            MouseWheel = Input.GetAxis("Mouse ScrollWheel");
        }
    }