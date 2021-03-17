using UnityEngine;

public class PlayerShootState : MonoBehaviour, ILoopState
{
    [SerializeField] private Transform shotPoint;
    
    public StateMachine StateMachine { get; private set; }

    private PlayerController _playerController;
    private Animator _animator;
    private GameObjectPool _pool;
    private IRayProvider _rayProvider;
    private ISelector _selector;
    private Transform _currentSelection;
    private float _nextShotTime;
    private float _shotDelay = 0.2f;
    private WayPoint[] _wayPoints;
    
    private static readonly int ShootHash = Animator.StringToHash("Shoot");

    public void Init(StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
        _pool = GetComponent<GameObjectPool>();
        _rayProvider = GetComponent<IRayProvider>();
        _selector = GetComponent<ISelector>();
        _wayPoints = FindObjectOfType<LevelController>().wayPoints;
    }

    public void EnterState()
    {
        _animator.SetBool(ShootHash, true);
    }

    public void HandleUpdate()
    {
        if (_wayPoints[_playerController.currentWayPoint].RemainingEnemies <= 0)
        {
            _animator.SetBool(ShootHash, false);
            StateMachine.ChangeState(PlayerState.Run.ToString());
        }
        
        if (Input.touchCount > 0 && CanShoot())
        {
            _selector.Check(_rayProvider.CreateRay());
            _currentSelection = _selector.GetSelection();
            if (_currentSelection != null)
            {
                _nextShotTime = Time.time + _shotDelay;
                var bullet = _pool.Get();
                bullet.GetComponent<Bullet>().Launch(shotPoint.position, shotPoint.rotation,
                    (_selector.GetHitPoint() - shotPoint.position).normalized);
                bullet.SetActive(true);
            }
        }
    }

    private bool CanShoot() => Time.time > _nextShotTime;

    public void HandleFixedUpdate()
    {
    }
}