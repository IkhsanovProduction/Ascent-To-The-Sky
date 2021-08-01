using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : MonoBehaviour, IState
{
    private readonly Animator _animator;

    public EnemyAttackState(Enemy enemy)
    {
        _animator = enemy.GetComponent<Animator>();
    }

    public void OnEnterState()
    {
       _animator.Play("Attack");
       GameManager.Instance.Player.TakeDamage(10);
    }

    public void OnExitState() { }

    public void OnStayState() { }
}
