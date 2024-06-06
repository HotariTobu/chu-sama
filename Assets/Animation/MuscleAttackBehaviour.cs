using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuscleAttackBehaviour : StateMachineBehaviour
{
    Vector3 first;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 tmp = new Vector3(0, 3f, -2f);
        GameObject Input1 = GameObject.Find("Main Camera");
        // tmp = Input1.transform.position - animator.transform.position;
        first = animator.transform.position;
        animator.transform.position = Input1.transform.position - tmp;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    // override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
        // while(animator.transform.position - ){
        //     animator.transform.position += new Vector3(tmp.x/180, tmp.y/180, tmp.z/180);
        // }
    // }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = first;
        GameObject Input1 = GameObject.Find("ScreenCrack(Clone)");
        Input1.name = "ScreenCrack1";
        Destroy(GameObject.Find("ScreenCrack1"));
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
