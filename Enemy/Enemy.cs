using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract Animator Animator { get; set; }
    public abstract int Life { get; set; }
    public abstract float Speed { get; set; }
    public abstract void Move();
    public abstract void Attack();
    public abstract void Die();
}
