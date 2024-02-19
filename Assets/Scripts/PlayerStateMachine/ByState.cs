using UnityEngine;

public class ByState : IState
{
    void IState.Enter(StateMachine _sm)
    {
        _sm.PMovement.SetSpeed(_sm.BySpeed);
    }

    void IState.Execute(StateMachine _sm)
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            _sm.ChangeState(_sm.HalfState);  
        } 
    }

    void IState.Exit(StateMachine _sm)
    {
        _sm.ShipAnimator.SetBool("isBy", false);
        _sm.ShipAnimator.SetBool("isHalf", true);
    }

    
}