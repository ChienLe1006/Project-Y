using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New OnReload", menuName = "Hung/Reload/OnReload")]
public class OnReload : Action
{
    public override void StateEnter(Animator animator, AnimatorStateInfo stateInfo)
    {
        
    }

    public override void StateUpdate(Animator animator, AnimatorStateInfo stateInfo)
    {
        
    }

    public override void StateExit(Animator animator, AnimatorStateInfo stateInfo)
    {
        animator.transform.parent.gameObject.SetActive(false);
        Cartridge.Instance.FinishReload();
        Weapon.Instance.FinishReload();
    }
}
