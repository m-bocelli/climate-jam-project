using UnityEngine;

public class ByState : IState
{
    void IState.Enter(StateMachine _sm)
    {
        _sm.PMovement.SetSpeed(_sm.BySpeed);
       // _sm.PMovement.SetTorque(60);
    }

    void IState.Execute(StateMachine _sm)
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            _sm.PMovement.boatSounds.ShipSailSound(1);
            _sm.ChangeState(_sm.HalfState);
        }
    }

    void IState.Exit(StateMachine _sm)
    {
        //_sm.PMovement.SetTorque(60);
        _sm.ShipAnimator.SetBool("isBy", false);
        _sm.ShipAnimator.SetBool("isHalf", true);
    }

    
}