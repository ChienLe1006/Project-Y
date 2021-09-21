using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hung/Movement/OnIdle")]
public class OnIdle : Action
{
    private Vector3 movement;

    public override void StateEnter(Animator animator, AnimatorStateInfo stateInfo)
    {
        
    }

    public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo)
    {
        movement = MovementJoystick.Instance.Direction + InputManager.Instance.keyboardMovement;

        if (movement.magnitude != 0)
        {
            animator.SetBool("IsWalking", true);
        }
    }

    public override void StateExit(Animator animator, AnimatorStateInfo stateInfo)
    {

    }
}
