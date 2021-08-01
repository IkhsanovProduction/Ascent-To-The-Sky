using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public abstract class Character : MonoBehaviour
{
    public abstract bool IsEnterToTransport { get; set; } 
    public abstract GameObject MeshRenderer { get; set; }
    public abstract bool IsDead { get; }
    public abstract Animator Animator { get; set; }
    public abstract float Speed { get; set; }
    public abstract int Health { get; set; }
    public abstract float RotationSpeed { get; set; }
    public abstract event EventHandler characterDied;
    public abstract void TakeDamage(int amount);
    public abstract void Die();
    public abstract void Move(float h, float v);
}
