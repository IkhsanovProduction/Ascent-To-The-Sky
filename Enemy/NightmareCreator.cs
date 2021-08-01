using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareCreator : Enemy
{
    IState _nightmareCreatorAttackState;
    IState _nightmareCreatorWalkState;
    IState _nightmareCreatorDieState;

    StateMachine _stateMachine = new StateMachine();

    [SerializeField] private RandomTarget _randomTarget;
    [SerializeField] private GameObject _dieEffect;
    [SerializeField] private float _speed;
    [SerializeField] private int _distanceToCharacter;

    private int _life = 500;

    public override int Life { get { return _life; } set { _life = value; } }
    public override float Speed { get { return _speed; } set { _speed = value; } }
    public override GameObject DieEffect { get { return _dieEffect; } set { _dieEffect = value; } }
    public override RandomTarget RandomTarget { get { return _randomTarget; } set { _randomTarget = value; } }

    void Start()
    {
        _nightmareCreatorAttackState = new EnemyAttackState(this);
        _nightmareCreatorWalkState = new EnemyWalkState(this);
        _nightmareCreatorDieState = new EnemyDieState(this);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!_isCanWalk)
            {
                _stateMachine.ChangeState(_nightmareCreatorAttackState);
                _nightmareCreatorWalkState.OnExitState();
            }
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            _stateMachine.ChangeState(_nightmareCreatorDieState);
        }
    }

    private bool _isCanWalk;

    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, GameManager.Instance.Player.transform.position) < _distanceToCharacter)
        {
            _isCanWalk = false;
        }

        else
        {
            _isCanWalk = true;
            _stateMachine.ChangeState(_nightmareCreatorWalkState);
        }

        _stateMachine.Update();
    }
}
   
