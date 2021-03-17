using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerRunState : MonoBehaviour, ILoopState
{
    
    private static readonly int RunHash = Animator.StringToHash("Run");
    public StateMachine StateMachine { get; private set; }

    private PlayerController _playerController;
    private NavMeshAgent _agent;
    private Animator _animator;
    private WayPoint[] _wayPoints;

    public void Init(StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _agent = GetComponent<NavMeshAgent>();
        _wayPoints = FindObjectOfType<LevelController>().wayPoints;
        _animator = GetComponent<Animator>();
    }

    public void EnterState()
    {
        _playerController.currentWayPoint++;
        _agent.SetDestination(_wayPoints[_playerController.currentWayPoint].transform.position);
        _animator.SetBool(RunHash, true);
    }

    public void HandleUpdate()
    {
        if (_agent.remainingDistance < 0.5)
        {
            StateMachine.ChangeState(PlayerState.Shoot.ToString());
        }
    }

    public void HandleFixedUpdate() { }
}