using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bugs : Enemy
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _randomTarget;
    [SerializeField] private GameObject _dieEffect;

    private int _life = 100;
    private Animator _animator;
    private bool _isAttack = false;
    private bool _isDead = false;
    private bool _isCanAttack = true;

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
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
        
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();

            if(Life <= 0)
            {
               Die();
            }  
        }
         
    }

    public void TakeDamage()
    {
        Life -= 20;
        _animator.Play("Take Damage");
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

    public override void Move()
    {
        if (Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position) < 10)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.Player.transform.position, _speed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(GameManager.Instance.Player.transform.position - transform.position), 10 * Time.deltaTime);

            if (_isAttack == false && _isDead == false)
            {
               _animator.Play("Run Forward W Root");
            }
        }

        else
        {
            _animator.Play("Walk Forward W Root");
            transform.position = Vector3.MoveTowards(transform.position, _randomTarget.position, 0.5f * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_randomTarget.position - transform.position), 10 * Time.deltaTime);
        }
    }

    void Update()
    {
        Move();
    }
}
