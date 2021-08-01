using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachine : MonoBehaviour
{
    private IState _currentState;

    public void ChangeState(IState newState)
    {
        if (_currentState != null)
            _currentState.OnExitState();

        _currentState = newState;
        _currentState.OnEnterState();
    }

    public void Update()
    {
        if (_currentState != null)
        {
            _currentState.OnStayState();
        }
    }
}
