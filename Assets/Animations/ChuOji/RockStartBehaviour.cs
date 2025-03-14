using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockStartBehaviour : StateMachineBehaviour
{
    GameObject Input1;
    private TextBehaviourScript textBehaviourScript;
    private GameManagerScript gameManagerScript;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject tmp_Perticle1 = Resources.Load<GameObject>("Characters/Stage2");
        GameObject Perticle1 = Instantiate(tmp_Perticle1);
        Input1 = GameObject.Find("Stage2(Clone)");
        Input1.name = "Stage1";
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    //    if(animator.transform.position.y <= 0.4f){
    //         animator.transform.position += new Vector3(0, 0.008f, 0);
    //     }

        if(Input1.transform.position.y <= -0.1f){
            Input1.transform.position += new Vector3(0, 0.008f, 0);
        }

        if(animator.transform.position.y <= 0.4f)
        {
            Vector3 targetPosition = animator.transform.position;
            targetPosition.y = 0.4f;
            animator.transform.position = Vector3.Lerp(animator.transform.position, targetPosition, Time.deltaTime);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
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
