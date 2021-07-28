using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboHelper : InteractableItemBase
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
        transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.Player.transform.position, Time.deltaTime * _speed);
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
