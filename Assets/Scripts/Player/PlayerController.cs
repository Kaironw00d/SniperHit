using System;
using UnityEngine;
using UnityEngine.AI;

public enum PlayerState
{
    Run,
    Shoot
}

public class PlayerController : MonoBehaviour
{
    public int currentWayPoint = 0;
    
    private StateMachine _stateMachine;
    private PlayerRunState _runState;
    private PlayerShootState _shootState;

    private void Awake()
    {
        _runState = GetComponent<PlayerRunState>();
        _shootState = GetComponent<PlayerShootState>();
        
        _stateMachine = new StateMachine(false, new StateConstructor(PlayerState.Run.ToString(), _runState),
            new StateConstructor(PlayerState.Shoot.ToString(), _shootState));
    }

    private void Start()
    {
        _stateMachine.ChangeState(PlayerState.Run.ToString());
    }

    private void Update()
    {
        _stateMachine.ProcessUpdate();
    }
}