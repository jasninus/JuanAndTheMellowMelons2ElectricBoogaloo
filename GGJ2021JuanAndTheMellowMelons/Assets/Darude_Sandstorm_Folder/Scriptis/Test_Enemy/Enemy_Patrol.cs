using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Patrol : StateMachineBehaviour
{
    [SerializeField] private Test_Enemy_Script enemyScript;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyScript = animator.GetComponent<Test_Enemy_Script>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemyScript.IsInRange)
        {
            animator.SetTrigger("Chase_Trigger");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Chase_Trigger");
    }

}
