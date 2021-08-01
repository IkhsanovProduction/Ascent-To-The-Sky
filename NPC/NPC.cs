using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : InteractableItemBase
{
    public abstract int Speed { get; set; }
    public abstract Animator Animator { get; set; }
    public abstract RandomTarget RandomTarget { get; set; }
    public abstract GameObject TalkPanel { get; set; }
}
