using UnityEngine;
using UnityEngine.AI;

public interface IState
{
    void OnEnterState();
    void OnStayState();
    void OnExitState();
}
