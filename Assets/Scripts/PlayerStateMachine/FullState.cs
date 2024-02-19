using UnityEngine;

public class FullState : IState 
{
    void IState.Enter(StateMachine _sm)
    {
        _sm.PMovement.SetSpeed(_sm.FullSpeed);
    }

    void IState.Execute(StateMachine _sm)
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            _sm.PMovement.boatSounds.ShipSailSound(1);
            _sm.ChangeState(_sm.HalfState); 
        }
    }

    void IState.Exit(StateMachine _sm)
    {
        _sm.ShipAnimator.SetBool("isFull", false);
        _sm.ShipAnimator.SetBool("isHalf", true);
    }
}