using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [CanBeNull][SerializeField] private IState _state;
    
    // Update is called once per frame
    void Update()
    {
        if (_state == null)
            return;
        if(_state is IUpdateable updateableState)
            updateableState.Update();
    }

    public void SetState(IState state)
    {
        _state = state;
    }
}
