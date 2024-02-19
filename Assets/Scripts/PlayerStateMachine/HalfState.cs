using UnityEngine;

public class HalfState : IState 
{
    private IState.NextState nextState;
    void IState.Enter(StateMachine _sm)
    {
        _sm.PMovement.SetSpeed(_sm.HalfSpeed);
    }

    void IState.Execute(StateMachine _sm)
    {

        if (Input.GetKeyDown(KeyCode.W)) {
            nextState = IState.NextState.Full;
            _sm.ChangeState(_sm.FullState);
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            nextState = IState.NextState.By;
            _sm.ChangeState(_sm.ByState); 
        }
    }

    void IState.Exit(StateMachine _sm)
    {
        _sm.ShipAnimator.SetBool("isHalf", false);

        if (nextState == IState.NextState.By) {
            _sm.ShipAnimator.SetBool("isBy", true);
        } else if (nextState == IState.NextState.Full) {
            _sm.ShipAnimator.SetBool("isFull", true);
        }
    }
}