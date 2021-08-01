using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieState : MonoBehaviour, IState
{
    private readonly Enemy _enemy;
    private readonly Animator _animator;

    public EnemyDieState(Enemy enemy)
    {
        this._enemy = enemy;
        _animator = enemy.GetComponent<Animator>();
    }
    public void TakeDamage()
    {
        _enemy.Life -= 20;
        _animator.Play("Take Damage");
    }

    public void OnEnterState()
    {
        TakeDamage();

        if (_enemy.Life <= 0)
        {
            Instantiate(_enemy.DieEffect, _enemy.transform.position, _enemy.transform.rotation);
            Destroy(_enemy.DieEffect, 2);
            _animator.Play("Die");
        }
    }

    public void OnExitState()
    {
        if(_enemy.Life <= 0)
        {
            Destroy(_enemy.gameObject);
        }
    }

    public void OnStayState() => OnExitState();
}
