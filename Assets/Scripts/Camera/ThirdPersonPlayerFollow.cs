using UnityEngine;

    public class ThirdPersonPlayerFollow : MonoBehaviour, IUpdateable, IState
    {
        private Transform _target;
        private Transform _source;
        private float distance = 2f;
        private Vector3 offset ;
        private float mouseSens = 1f;
        private readonly AMouseInput _mouseManager;

        public ThirdPersonPlayerFollow(Transform target, Transform source)
        {
            _target = target;
            _source = source;
            _mouseManager = InputManager.CurrentMouseInput;
        }

        public void Update()
        {
            var targetPosition = _target.position;
            
            _mouseManager.Update();
            
            var mouseX = _mouseManager.MouseX * mouseSens * Time.deltaTime;
            var mouseY = _mouseManager.MouseY * mouseSens * Time.deltaTime;

            distance += _mouseManager.MouseWheel;

            distance = Mathf.Clamp(distance, 2f, 5f); 
            
            var rotatedOffsetXZOsX = offset.x * Mathf.Cos(mouseX) 
                                         - offset.z * Mathf.Sin(mouseX);
            var rotatedOffsetXZOsY = offset.x * Mathf.Sin(mouseX) 
                                         + offset.z * Mathf.Cos(mouseX);
            var rotatedOffsetXZ = new Vector3(rotatedOffsetXZOsX, offset.y, rotatedOffsetXZOsY);
            offset = rotatedOffsetXZ;

            var rotatedOffsetYZOsZ = offset.y * Mathf.Sin(mouseY) 
                                     + offset.z * Mathf.Cos(mouseY);
            var rotatedOffsetYZOsY = offset.y * Mathf.Cos(mouseY) 
                                     - offset.z * Mathf.Sin(mouseY);
            var rotatedOffsetYZ = new Vector3(offset.x, rotatedOffsetYZOsY, rotatedOffsetYZOsZ);
            offset = rotatedOffsetYZ;
            var newPos = targetPosition + offset;
            var newPosDistanceV = newPos - targetPosition;
            _source.position = targetPosition + Vector3.ClampMagnitude(newPosDistanceV, distance);
            
            _source.LookAt(targetPosition); 
        }
    }