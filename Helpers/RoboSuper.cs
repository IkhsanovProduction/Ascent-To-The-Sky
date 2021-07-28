using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboSuper : InteractableItemBase
{
    [SerializeField] private int _speed;
    private bool isMove = false;

    void Update()
    {
        if (isMove)
        {
            Move();
        }
    }

    void Move()
    {
        if (Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position) > 5)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.Player.transform.position, Time.deltaTime * _speed);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(GameManager.Instance.Player.transform.position - transform.position), 5 * Time.deltaTime);
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
            value += 2;
            PlayerPrefs.SetInt("Supplier", value);
        }
    }
}
