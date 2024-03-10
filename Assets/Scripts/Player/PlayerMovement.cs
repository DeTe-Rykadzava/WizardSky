using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform camera;
    [SerializeField] private PlayerMovementSpecifications _specification;
    
    private int _countAbleJumps;
    
    private AInput _inputManager;
    
    private bool _isCharacterControllerNull;
    
    private Vector3 _verticalVelocity = Vector3.zero;
    private bool _isCameraNull;

    void Start()
    {
        _isCameraNull = camera == null;
        _isCharacterControllerNull = _characterController == null;
        _inputManager = InputManager.CurrentInput;
        _countAbleJumps = _specification.MaxCountJumps;
    }

    // Update is called once per frame
    void Update()
    {
        _inputManager.Update();
    }
    
    private void FixedUpdate()
    {
        if (_isCharacterControllerNull)
            return;
        
        if (_characterController.isGrounded)
        {
            if (_verticalVelocity.y < 0)
                _verticalVelocity.y = 0f;
            // Debug.Log("Move");
            _countAbleJumps = _specification.MaxCountJumps;
            var move = new Vector3(_inputManager.LeftRight, 0, _inputManager.ForwardBack);
            if(_inputManager.Sprint)
                _characterController.Move(move * Time.fixedDeltaTime * (_specification.Speed + _specification.SprintSpeed));
            else
                _characterController.Move(move * Time.fixedDeltaTime * _specification.Speed);
        }
        else
        {
            // Debug.Log("Move in space");
            var move = new Vector3(_inputManager.LeftRight, 0, _inputManager.ForwardBack);
            // _characterController.Move(move * Time.fixedDeltaTime * _specification.Speed);
            
            _characterController.Move(move * 0.75f * Time.fixedDeltaTime * _specification.Speed);
        }
        
        if (_inputManager.Jump && _countAbleJumps != 0)
        {
            Debug.Log("Jump");
            
            _countAbleJumps--;
            Debug.Log($"Count able jumps: {_countAbleJumps}");
            // _verticalVelocity.y += Mathf.Sqrt(_specification.JumpHeight / _specification.JumpForce * _specification.Gravity);
            _verticalVelocity.y = _specification.JumpHeight * _specification.JumpForce;
            Debug.Log(_verticalVelocity);
        }

        _verticalVelocity.y += _specification.Gravity * Time.fixedDeltaTime;
        
        _characterController.Move(_verticalVelocity * Time.fixedDeltaTime);
        
    }

    private void LateUpdate()
    {
        if(_isCameraNull)
            return;

        var cameraRotation = camera.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, cameraRotation.y, 0);
    }
}
