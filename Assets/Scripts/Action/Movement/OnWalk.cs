using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "Hung/Movement/OnWalk")]
public class OnWalk : Action
{
    private Vector3 movement;
    public Vector3 right;
    public Vector3 left;
    public Joystick Enstance;
    public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo)
    {
        movement = MovementJoystick.Instance.Direction + InputManager.Instance.keyboardMovement;

        //Debug.Log(movement); 

        Player.Instance.Movement = movement;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        if (movement.x > 0) animator.transform.localScale = right;
        else animator.transform.localScale = left;


        if (movement.magnitude == 0)
        {
            animator.SetBool("IsWalking", false);
        }
    }

    public override void StateEnter(Animator animator, AnimatorStateInfo stateInfo)
    {
        
    }

    public override void StateExit(Animator animator, AnimatorStateInfo stateInfo)
    {

    }
}
