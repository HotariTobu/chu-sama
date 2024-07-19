using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuscleAttackBehaviour : StateMachineBehaviour
{
    Vector3 first;
    private GameManagerScript gameManagerScript;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject gameManagerObject = GameObject.Find("GameManager");
        gameManagerScript = gameManagerObject.GetComponent<GameManagerScript>();
        gameManagerScript.splineAnimate.enabled = false;
        gameManagerScript.Attackjudge = true;
        first = animator.transform.position;

        Vector3 newPosition = animator.transform.position;
        newPosition.x = gameManagerScript.target4.transform.position.x;
        newPosition.y -= 0.35f;
        newPosition.z = gameManagerScript.target4.transform.position.z;
        animator.transform.position = newPosition;
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
        GameObject gameManagerObject = GameObject.Find("GameManager");
        gameManagerScript = gameManagerObject.GetComponent<GameManagerScript>();
        gameManagerScript.splineAnimate.enabled = true;

        GameObject Input1 = GameObject.Find("ScreenCrack(Clone)");
        Input1.name = "ScreenCrack1";
        Destroy(GameObject.Find("ScreenCrack1"));
        gameManagerScript.Attackjudge = false;
        animator.transform.position = first;
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
