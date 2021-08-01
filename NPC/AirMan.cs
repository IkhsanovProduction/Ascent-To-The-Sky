using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AirMan : NPC
{
    IState _airManWalkState;
    IState _airManTalkState;

    readonly StateMachine _stateMachine = new StateMachine();

    [SerializeField] private RandomTarget _randomTarget;
    [SerializeField] private int _speed;
    [SerializeField] private GameObject _talkPanel;
    [SerializeField] private int _distanceValue;
    
    private Animator _animator;

    public override int Speed { get { return _speed; } set { _speed = value; } }
    public override Animator Animator { get { return _animator; } set { _animator = value; } }
    public override RandomTarget RandomTarget { get { return _randomTarget; } set { _randomTarget = value; } }
    public override GameObject TalkPanel { get { return _talkPanel; } set { _talkPanel = value; } }

    void Start()
    {
        _airManWalkState = new NPCWalkState(this);
        _airManTalkState = new NPCTalkState(this);
    }

    public override void OnInteract()
    {
        base.OnInteract();
    }

    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, GameManager.Instance.Player.transform.position) < _distanceValue)
        {
            _stateMachine.ChangeState(_airManTalkState);
            _airManWalkState.OnExitState();
        }

        else
        {
            _stateMachine.ChangeState(_airManWalkState);
        }

        _stateMachine.Update();
    }
}
