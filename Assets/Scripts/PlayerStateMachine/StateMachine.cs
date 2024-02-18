using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IState currState;
    [HideInInspector] public ByState ByState = new();
    [HideInInspector] public HalfState HalfState = new();
    [HideInInspector] public FullState FullState = new();

    public Animator ShipAnimator;
    public PlayerMovement PMovement;

    [Header("State Speeds")]
    public float BySpeed = 0f;
    public float HalfSpeed = 10f;
    public float FullSpeed = 30f;

    private void Start() 
    {
        ShipAnimator = GetComponent<Animator>();
        PMovement = GetComponent<PlayerMovement>();
        ChangeState(ByState);
    }

    private void Update()
    {
        currState?.Execute(this);
    }

    public void ChangeState(IState _newState)
    {
        currState?.Exit(this);
        currState = _newState;
        currState?.Enter(this);
    }
}

public interface IState
{
    public enum NextState {By, Half, Full};
    public void Enter(StateMachine _sm);
    public void Execute(StateMachine _sm);
    public void Exit(StateMachine _sm);
}