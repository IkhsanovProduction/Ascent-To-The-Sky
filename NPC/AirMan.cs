using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMan : NPC
{
    [Header("Random coordinates(Min and Max)")]
    [SerializeField] private int _moveSpotMin;
    [SerializeField] private int _moveSpotMax;

    [SerializeField] private int _speed;
    [SerializeField] private float _startWaitTime;
    [SerializeField] private Transform _moveSpot;
    [SerializeField] private bool _isCanWalk = false;

    [SerializeField] private GameObject _talkPanel;

    private Animator _animator;
    private float _waitTime;
    private bool _isInteract = false;

    private int _distanceValue = 5;
    private int _moveDistanceValue = 20;
    private int _rotationSpeed = 10;

    public override int Speed { get { return _speed; } set { _speed = value; } }
    public override Animator Animator { get { return _animator; } set { _animator = value; } }

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _waitTime = _startWaitTime;

        _moveSpot.position = new Vector3(Random.Range(_moveSpotMin, _moveSpotMax), 
                                        transform.position.y, Random.Range(_moveSpotMin, _moveSpotMax));
    }

    void Update()
    {
        if (_isInteract)
        {
            if (Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position) < 5)
            {
                _talkPanel.SetActive(true);
            }

            else
            {
                _talkPanel.SetActive(false);
                _isInteract = false;
            }
        }

        Move();
    }

    public override void OnInteract()
    {
        _isInteract = true;
    }

    public void CheckForDistance()
    {
        if (Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position) < _distanceValue)
        {
            _speed = 0;
            _animator.Play("Idle");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(GameManager.Instance.Player.transform.position - transform.position), _rotationSpeed * Time.deltaTime);
        }

        else
        {
            _speed = 2;
        }

        if (Vector3.Distance(transform.position, _moveSpot.position) < _moveDistanceValue)
        {
            if (_waitTime <= 0)
            {
                _moveSpot.position = new Vector3(Random.Range(_moveSpotMin, _moveSpotMax), transform.position.y, Random.Range(_moveSpotMin, _moveSpotMax));
                _waitTime = _startWaitTime;
            }

            else
            {
                _waitTime -= Time.deltaTime;
            }
        }
    }

    public void NoneWalk(int distance)
    {
        if (Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position) < distance)
        {
            _speed = 0;
            _animator.Play("Idle");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(GameManager.Instance.Player.transform.position - transform.position), _rotationSpeed * Time.deltaTime);
        }
    }

    public override void Move()
    {
        if (_isCanWalk)
        {
            transform.position = Vector3.MoveTowards(transform.position, _moveSpot.position, _speed * Time.deltaTime);
            _animator.SetBool("run", transform.position.magnitude > 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_moveSpot.position - transform.position), _rotationSpeed * Time.deltaTime);

            CheckForDistance();
        }

        else
        {
            NoneWalk(30);
        }
    }
}
