using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    public float duration;
    public abstract void StateUpdate(Animator animator, AnimatorStateInfo stateInfo);
    public abstract void StateEnter(Animator animator, AnimatorStateInfo stateInfo);
    public abstract void StateExit(Animator animator, AnimatorStateInfo stateInfo);
}
