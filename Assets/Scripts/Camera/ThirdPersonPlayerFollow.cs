using Camera;
using UnityEngine;

    public class ThirdPersonPlayerFollow : ILateUpdate, IState
    {
        private readonly Transform _target;
        private readonly Transform _source;

        private const float MinDistance = 2f;
        private const float MaxDistance = 2f;
        private const float MouseSens = 1f;
        private const float VerticalAngleLimit = 80;
        
        private float _distance = 2f;
        private Vector3 offset = new Vector3(0,2, -2);
        
        private float verticalRotation = 0f;

        private readonly AMouseInput _mouseInput;
        private bool _isTargetNull;
        private bool _isSourceNull;

        public ThirdPersonPlayerFollow(Transform target, Transform source)
        {
            _target = target;
            _source = source;
            _mouseInput = InputManager.CurrentMouseInput;
            CheckVariable();
        }

        private void CheckVariable()
        {
            _isSourceNull = _source == null;
            _isTargetNull = _target == null;
        }


        public void LateUpdate()
        {
            _mouseInput.Update();
           
            if (_isTargetNull || _isSourceNull)
            {
                return;
            }

            var mouseX = _mouseInput.MouseX * MouseSens ;
            var mouseY = _mouseInput.MouseY * MouseSens ;

            _distance += _mouseInput.MouseWheel;

            _distance = Mathf.Clamp(_distance, MinDistance, MaxDistance);

            verticalRotation -= mouseY;
            verticalRotation = Mathf.Clamp(verticalRotation, -VerticalAngleLimit, VerticalAngleLimit);

            var rotation = Quaternion.Euler(mouseY, mouseX, 0) ;
            offset = rotation * offset;

            var position = _target.position;
            var desiredPosition = position + offset * _distance;

            _source.position = desiredPosition;
            _source.LookAt(position);
        }
    }