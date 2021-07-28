using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareCreator : Enemy
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _randomTarget;
    [SerializeField] private GameObject _dieEffect;
    [SerializeField] private Transform _moveSpot;
    [SerializeField] private float _startWaitTime;

    [SerializeField] private int _moveSpotMin;
    [SerializeField] private int _moveSpotMax;
   
    private float _waitTime;
    private int _moveDistanceValue = 20;
    private int _rotationSpeed = 10;

    private int _life = 100;
    private Animator _animator;
    private bool _isAttack = false;
    private bool _isDead = false;
    private bool _isCanAttack = true;

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _waitTime = _startWaitTime;

        _moveSpot.position = new Vector3(Random.Range(_moveSpotMin, _moveSpotMax),
                                        transform.position.y, Random.Range(_moveSpotMin, _moveSpotMax));
    }

    public override float Speed { get { return _speed; } set { _speed = value; } }
    public override int Life { get { return _life; } set { _life = value; } }
    public override Animator Animator { get { return _animator; } set { _animator = value; } }

    public override void Attack()
    {
        if (_isCanAttack)
        {
            _isAttack = true;
            _animator.Play("Smash Attack");
            GameManager.Instance.Player.TakeDamage(10);
            StartCoroutine("ReturnAttackAnimation");
        }
    }

    IEnumerator ReturnAttackAnimation()
    {
        yield return new WaitForSeconds(2);
        _isAttack = false;
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Attack();
        }

        InteractableItemBase item = collision.collider.gameObject.GetComponent<InteractableItemBase>();
        if (item != null)
        {
            if (item.ItemType == EItemType.Weapon)
            {
                if (GameManager.Instance.Player.IsAttacking)
                {
                    GetAttack();

                    if (Life <= 0)
                    {
                        Die();
                    }
                }
            }
        }
    }

    public void GetAttack()
    {
        Life -= 20;
        _animator.Play("Basic Attack");
    }


    public override void Die()
    {
        Instantiate(_dieEffect, transform.position, transform.rotation);
        Destroy(_dieEffect, 2);
        _isDead = true;
        _isCanAttack = false;
        _animator.Play("Die");
        _speed = 0;

        StartCoroutine(DestroyObject());

        Invoke("ShowItemsDeadState", 1.2f);
    }

    public void CheckForDistance()
    {
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

    public override void Move()
    {
        if (Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position) < 10)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.Player.transform.position, _speed*2 * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(GameManager.Instance.Player.transform.position - transform.position), 10 * Time.deltaTime);

            if (_isAttack == false && _isDead == false)
            {
                _animator.Play("Run");
            }
        }

        else
        {
            _animator.Play("Walk");
            transform.position = Vector3.MoveTowards(transform.position, _moveSpot.position, _speed * Time.deltaTime);
            
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_moveSpot.position - transform.position), _rotationSpeed * Time.deltaTime);

            CheckForDistance();
        }
    }

    void Update()
    {
        Move();
    }
}
