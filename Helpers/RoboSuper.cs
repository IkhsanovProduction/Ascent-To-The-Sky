using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoboSuper : InteractableItemBase
{
    [SerializeField] private int _speed;
    private NavMeshAgent _roboNavMesh;
    private Transform _target;

    private bool isMove = false;

    void Start()
    {
        _roboNavMesh = gameObject.GetComponent<NavMeshAgent>();
        _target = GameManager.Instance.Player.transform;
    }


    void Update()
    {
        if (isMove)
        {
            Move();
        }
    }

    void Move()
    {
        if (Vector3.Distance(transform.position, _target.position) > 5)
        {
            _roboNavMesh.SetDestination(_target.position);
        }
           
    }

    public override void OnInteract()
    {
        RoboOn();
    }

    public void RoboOn()
    {
        if (!isMove)
        {
            isMove = true;
        }

        else
        {
            RoboOff();
        }

    }

    public void RoboOff()
    {
        isMove = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Supplier"))
        {
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            int value = PlayerPrefs.GetInt("Supplier");
            value += 1;
            PlayerPrefs.SetInt("Supplier", value);
        }
    }
}
