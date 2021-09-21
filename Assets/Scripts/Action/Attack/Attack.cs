using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack", menuName = "Hung/Attack/Attack")]
public class Attack : Action
{
    
    //public bool isAlreadyCalled;
    private Vector3 movement;

    public override void StateEnter(Animator animator, AnimatorStateInfo stateInfo)
    {
        //isAlreadyCalled = false;
    }

    public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo)
    {
        if (FiringJoystick.Instance.Direction.magnitude != 0)
        {
            //isAlreadyCalled = true;
            animator.SetBool("IsFiring", true);
            Weapon.Instance.Fire(FiringJoystick.Instance.Direction);             
        }
    }

    public override void StateExit(Animator animator, AnimatorStateInfo stateInfo)
    {

    }
}