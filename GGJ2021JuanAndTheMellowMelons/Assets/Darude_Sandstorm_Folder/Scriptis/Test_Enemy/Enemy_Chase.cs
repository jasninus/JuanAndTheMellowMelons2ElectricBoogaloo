using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Chase : StateMachineBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody enemyRigidbody;
    [SerializeField] private Test_Enemy_Script enemyScript;
    public float speed = 2.5f;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        enemyScript = animator.GetComponent<Test_Enemy_Script>();
        enemyRigidbody = animator.GetComponent<Rigidbody>();
    }

     //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var target = playerTransform.position;
        var newPosition = Vector3.MoveTowards(enemyRigidbody.position, target, speed * Time.fixedDeltaTime);
        enemyRigidbody.MovePosition(newPosition);
        if (enemyScript.IsInRange)
            animator.SetTrigger("Attack");
    }

     //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
    
    
}
