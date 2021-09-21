using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New OnAttack", menuName = "Hung/Ability/OnAttack")]
public class OnAttack : Action
{
    
    private Vector2 direction;

    public override void StateEnter(Animator animator, AnimatorStateInfo stateInfo)
    {
        
    }

    public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo)
    {
        direction = FiringJoystick.Instance.Direction;
        if (direction == Vector2.zero)
        {
            Weapon.Instance.Stop();
            animator.SetBool("IsFiring", false);
        }
        else
        {
            Weapon.Instance.Direction(direction);
        }
    }

    public override void StateExit(Animator animator, AnimatorStateInfo stateInfo)
    {
        
    }
}