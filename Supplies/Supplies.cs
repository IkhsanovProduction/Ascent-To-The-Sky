using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Supplies : InteractableItemBase
{
    public abstract GameObject Copy { get; set; }
    public abstract int PowerValue { get; set; }
    public abstract void AddValueToPlayer();

}
