using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalBehaiver : MonoBehaviour
{
    Animator animator;
    int cnt;
    private GameObject gameManager;
    private GameManagerScript gameManagerScript;
    private HealthBehaviourScript healthBehaviourScript;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();
        healthBehaviourScript = gameManager.GetComponent<HealthBehaviourScript>();
        animator = GetComponent<Animator>();
        cnt = 0;
    }

    
    void Update()
    {
        if(gameManagerScript.process8 == true && gameManagerScript.isCollect == false){
            gameManagerScript.process8 = false;
            Invoke(nameof(DelayMethod4), 1.5f);
            Invoke(nameof(DelayMethod1), 2.1f);
        }

        if(gameManagerScript.process8 == true && gameManagerScript.isCollect == true){
            gameManagerScript.process8 = false;
            Invoke(nameof(DelayMethod3), 1.2f);
            cnt++;
        }

        if(gameManagerScript.DestSign == true){
            gameManagerScript.DestSign = false;
            Invoke(nameof(DelayMethod2), 0.3f);
        }
    }

    void DelayMethod1(){
        GameObject tmp = Resources.Load<GameObject>("Characters/MajicBall");
        GameObject MajicAttack = Instantiate(tmp);
        GameObject Input1 = GameObject.Find("MajicBall(Clone)");
        GameObject Input2 = GameObject.Find("Main Camera");
        Vector3 direction = new Vector3(Input2.transform.position.x - this.gameObject.transform.position.x, Input2.transform.position.y - this.gameObject.transform.position.y, Input2.transform.position.z - this.gameObject.transform.position.z);
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up) * Quaternion.Euler(0f, 180f, 0f);
        Vector3 eulerAngles = targetRotation.eulerAngles;
        Vector3 Angles = new Vector3(-23f, -5f, 0f);
        Input1.transform.Rotate(eulerAngles + Angles);
    }

    void DelayMethod2(){
        Destroy(this.gameObject);
        healthBehaviourScript.health++;
    }

    void DelayMethod3(){
        animator.SetTrigger("Damaged Trigger");
        Invoke(nameof(DelayMethod5), 1f);
    }

    void DelayMethod4(){
        animator.SetTrigger("Attack Trigger");
    }

    void DelayMethod5(){
        gameManagerScript.process9 = true;
    }
}
