using System;
using TMPro;
using UnityEngine;

public class LevelPlayingState : BaseEventState
{
    [SerializeField] private LevelState state;
    private LevelController _levelController;
    
    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);
        Name = state.ToString();
    }

    public void Init(LevelController levelController)
    {
        _levelController = levelController;
    }

    public override void HandleState(string stateName)
    {
        if(!base.CanHandleState(stateName)) return;
        
        base.HandleState(stateName);
        _levelController.player.enabled = true;
    }
}