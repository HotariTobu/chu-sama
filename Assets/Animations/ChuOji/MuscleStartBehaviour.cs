using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuscleBehavior : StateMachineBehaviour
{
    private TextBehaviourScript textBehaviourScript;
    private GameManagerScript gameManagerScript;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    // override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //     GameObject gameManagerObject = GameObject.Find("GameManager");
    //     gameManagerScript = gameManagerObject.GetComponent<GameManagerScript>();
    //     gameManagerScript.splineAnimate.enabled = false;
    // }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       GameObject Input1 = GameObject.Find("EarthCrack(Clone)");
        Input1.name = "EarthCrack1";
        Destroy(GameObject.Find("EarthCrack1"));

        GameObject obj = GameObject.Find("GameManager");
        textBehaviourScript = obj.GetComponent<TextBehaviourScript>();
        textBehaviourScript.TextsM.enabled = false;
        gameManagerScript = obj.GetComponent<GameManagerScript>();
        gameManagerScript.process3 = true;

        gameManagerScript.splineAnimate.enabled = true;
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
