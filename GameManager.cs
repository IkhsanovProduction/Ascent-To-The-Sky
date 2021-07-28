using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public static GameManager Instance { get; private set; }

    private GameManager()
    {
        Instance = this;
    }

    [SerializeField] private Player _player;
    public Player Player { get { return _player; } set { _player = value; } }

    void Start()
    {
        DontDestroyOnLoad(this);
    } 
}
