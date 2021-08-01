using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCWalkState : IState
{
    private readonly NPC _npc;
    private readonly NavMeshAgent _agent;
    private readonly Animator _animator;
    private readonly RandomTarget _randomTarget;
    private float _speed;
    bool _isCanWalk;

    public NPCWalkState(NPC npc)
    {
        _npc = npc;
        _animator = npc.GetComponent<Animator>();
        _agent = npc.gameObject.GetComponent<NavMeshAgent>();
        _randomTarget = npc.RandomTarget;
        _speed = npc.Speed;
    }

    public void OnEnterState()
    {
        _isCanWalk = true;
        _agent.speed = _speed;
        _animator.SetBool("run", _npc.transform.position.magnitude > 0);
    }

    public void OnExitState()
    {
        _isCanWalk = false;
        _agent.speed = 0;
    }

    public void OnStayState()
    {
        if (_isCanWalk)
        {
            _agent.SetDestination(_randomTarget.transform.position);
            _randomTarget.DistanceCheck(_npc.gameObject);
        }
    }
}
