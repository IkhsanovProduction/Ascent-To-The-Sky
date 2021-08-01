using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalkState : MonoBehaviour, IState
{
    private readonly Enemy _enemy;
    private readonly NavMeshAgent _agent;
    private readonly Animator _animator;
    
    private readonly RandomTarget _randomTarget;
    private readonly float _speed;
    bool _isCanWalk;

    public EnemyWalkState(Enemy enemy) 
    { 
        this._enemy = enemy;
        _animator = enemy.GetComponent<Animator>();
        _agent = enemy.gameObject.GetComponent<NavMeshAgent>();
        _randomTarget = enemy.RandomTarget;
        _speed = enemy.Speed;
    }

    public void OnEnterState()
    {
        _isCanWalk = true;
        _agent.speed = _speed;
    }

    public void OnExitState()
    {
        _isCanWalk = false;
    }

    public void OnStayState()
    {
        if (Vector3.Distance(_enemy.transform.position, GameManager.Instance.Player.transform.position) < 15)
        {
            _agent.SetDestination(GameManager.Instance.Player.transform.position);

            if (_isCanWalk)
            {
                _animator.Play("Run");
            }
        }

        else
        {
            _animator.Play("Walk");
            _agent.SetDestination(_randomTarget.gameObject.transform.position);
        }

        _randomTarget.DistanceCheck(_enemy.gameObject);
    }
}
