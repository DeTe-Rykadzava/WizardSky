using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [CanBeNull] public static GameManager CurrentGameManager { get; private set; }

    [SerializeField] private CameraManager _cameraManager;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _player;
    
    private void Awake()
    {
        if(_cameraManager != null && _camera!= null && _player != null)
            _cameraManager.SetState(new ThirdPersonPlayerFollow(_player, _camera));
        CurrentGameManager = this;
    }
}
