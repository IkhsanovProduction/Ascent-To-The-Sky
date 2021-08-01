using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract int Life { get; set; }
    public abstract float Speed { get; set; }
    public abstract GameObject DieEffect { get; set; }
    public abstract RandomTarget RandomTarget { get; set; }
}
