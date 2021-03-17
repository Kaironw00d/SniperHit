using UnityEngine;

public enum LevelState
{
    Waiting,
    Playing
}

public class LevelController : MonoBehaviour
{
    private StateMachine _stateMachine;
    private LevelWaitingState _waitingState;
    private LevelPlayingState _playingState;

    public WayPoint[] wayPoints;
    public PlayerController player;
    
    private void Awake()
    {
        _waitingState = GetComponent<LevelWaitingState>();
        _playingState = GetComponent<LevelPlayingState>();
        _playingState.Init(this);
        _stateMachine = new StateMachine(true, new StateConstructor(LevelState.Waiting.ToString(), _waitingState),
            new StateConstructor(LevelState.Playing.ToString(), _playingState));

        InitPlayer();
    }

    private void InitPlayer()
    {
        var wayPointTransform = wayPoints[0].transform;
        var go = Instantiate(Resources.Load("Prefabs/Player") as GameObject, wayPointTransform.position, wayPointTransform.rotation);
        player = go.GetComponent<PlayerController>();
    }

    private void Start()
    {
        _stateMachine.ChangeState(LevelState.Waiting.ToString());
    }
}