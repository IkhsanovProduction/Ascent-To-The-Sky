using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRobot : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _pos;
    [SerializeField] private int bulletSpeed;
    private int _distanceValue = 20;

    void Shoot()
    {
       
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(_bullet, _pos.transform.position, _pos.transform.rotation) as GameObject;

        Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 360);

        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

        Temporary_RigidBody.AddForce(transform.forward * bulletSpeed);

        Destroy(Temporary_Bullet_Handler, 5.0f);
    }


   

    void CheckDistance()
    {
        if (Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position) < _distanceValue)
        {
            Shoot();
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(GameManager.Instance.Player.transform.position - transform.position), 10 * Time.deltaTime);
        }
    }

    void Update()
    {
        CheckDistance();
    }
}
