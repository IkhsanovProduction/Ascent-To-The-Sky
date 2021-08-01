using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Bug : Enemy
{
    IState _bugAttackState;
    IState _bugWalkState;
    IState _bugDieState;

    [SerializeField] private RandomTarget _randomTarget;
    [SerializeField] private GameObject _dieEffect;
    [SerializeField] private float _speed;
    [SerializeField] private int _distanceToCharacter;

    private StateMachine _stateMachine = new StateMachine();
   
    private int _life = 100;

    public override int Life { get { return _life; } set { _life = value; } }
    public override float Speed { get { return _speed; } set { _speed = value; } }
    public override GameObject DieEffect { get { return _dieEffect; } set { _dieEffect = value; } }
    public override RandomTarget RandomTarget { get { return _randomTarget; } set { _randomTarget = value; } }

    void Start()
    {
        _bugAttackState = new EnemyAttackState(this);
        _bugWalkState = new EnemyWalkState(this);
        _bugDieState = new EnemyDieState(this);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!_isCanWalk)
            {
                _stateMachine.ChangeState(_bugAttackState);
                _bugWalkState.OnExitState();
            }
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            _stateMachine.ChangeState(_bugWalkState);
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
            _stateMachine.ChangeState(_bugWalkState);
        }

        _stateMachine.Update();
    }
}
