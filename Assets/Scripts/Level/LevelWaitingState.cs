using UnityEngine;
using UnityEngine.UI;

public class LevelWaitingState : BaseEventState
{
    [SerializeField] private LevelState state;
    [SerializeField] private Button playButton;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        playButton.onClick.AddListener(ExitState);
    }

    public override void Init(StateMachine stateMachine)
    {
        base.Init(stateMachine);
        Name = state.ToString();
    }

    public override void HandleState(string stateName)
    {
        if(!base.CanHandleState(stateName)) return;
        
        base.HandleState(stateName);
        playButton.gameObject.SetActive(true);
    }

    private void ExitState()
    {
        playButton.gameObject.SetActive(false);
        StateMachine.ChangeState(LevelState.Playing.ToString());
    }
}