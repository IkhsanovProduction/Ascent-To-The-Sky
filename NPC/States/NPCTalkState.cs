using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalkState : IState
{
    private readonly NPC _npc;
    private readonly Animator _animator;
    private GameObject _talkPanel;

    public NPCTalkState(NPC npc)
    {
        _npc = npc;
        _animator = npc.GetComponent<Animator>();
        _talkPanel = npc.TalkPanel;
    }

    public void OnEnterState()
    {
        _talkPanel.SetActive(true);
    }

    public void OnExitState()
    {
        _talkPanel.SetActive(false);
    }

    public void OnStayState()
    {
        _animator.Play("Idle");
        _npc.transform.rotation = Quaternion.Slerp(_npc.transform.rotation,
                                  Quaternion.LookRotation(GameManager.Instance.Player.transform.position - _npc.transform.position),
                                  2 * Time.deltaTime);
    }
}
