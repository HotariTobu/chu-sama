using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalStartBehaviour : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    private TextBehaviourScript textBehaviourScript;
    private GameManagerScript gameManagerScript;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject tmp_Perticle1 = Resources.Load<GameObject>("Characters/MajicCircle");
        GameObject Perticle1 = Instantiate(tmp_Perticle1);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(animator.transform.position.y <= 0f){
            animator.transform.position += new Vector3(0, 0.0035f, 0);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject Input1 = GameObject.Find("MajicCircle(Clone)");
        Input1.name = "MajicCircle1";
        Destroy(GameObject.Find("MajicCircle1"));

        GameObject obj = GameObject.Find("GameManager");
        textBehaviourScript = obj.GetComponent<TextBehaviourScript>();
        textBehaviourScript.TextsM.enabled = false;
        gameManagerScript = obj.GetComponent<GameManagerScript>();
        gameManagerScript.process3 = true;
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
