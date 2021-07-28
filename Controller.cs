using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    
    void Update()
    {
        if(GameManager.Instance.Player != null)
        {
            GameManager.Instance.Player.Move(joystick.Horizontal, joystick.Vertical);
        }
    }
}
