using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviourScript : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        if(gameManagerScript.process8 == true && gameManagerScript.isCollect == false){
            gameManagerScript.process8 = false;
            Invoke(nameof(DelayMethod4), 0.7f);
            Invoke(nameof(DelayMethod1), 2.1f);
        }

        if(gameManagerScript.process8 == true && gameManagerScript.isCollect == true){
            gameManagerScript.process8 = false;
            Invoke(nameof(DelayMethod3), 1.2f);
            cnt++;
        }

        if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.P)){
            Destroy(this.gameObject);
            GameObject Input1 = GameObject.Find("Stage1");
            Destroy(Input1);
        }

        if(gameManagerScript.DestSign == true){
            gameManagerScript.DestSign = false;
            Invoke(nameof(DelayMethod2), 0.3f);
        }
    }

    void DelayMethod1(){
        GameObject tmp = Resources.Load<GameObject>("Characters/Razer");
        GameObject RockAttack = Instantiate(tmp);
        GameObject Input1 = GameObject.Find("Razer(Clone)");
        GameObject Input2 = GameObject.Find("Main Camera");
        Vector3 direction = new Vector3(Input2.transform.position.x - this.gameObject.transform.position.x, Input2.transform.position.y - this.gameObject.transform.position.y, Input2.transform.position.z - this.gameObject.transform.position.z);
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up) * Quaternion.Euler(0f, 180f, 0f);
        Vector3 eulerAngles = targetRotation.eulerAngles;
        Vector3 Angles = new Vector3(-17f, 0f, 0f);
        Input1.transform.Rotate(eulerAngles + Angles);
    }

    void DelayMethod2(){
        Destroy(this.gameObject);
        healthBehaviourScript.health++;
        GameObject Input1 = GameObject.Find("Stage1");
        Destroy(Input1);
    }

    void DelayMethod3(){
        animator.SetTrigger("Damaged Trigger");
        gameManagerScript.SEprocess10 = true;
        Invoke(nameof(DelayMethod5), 1f);
    }

    void DelayMethod4(){
        animator.SetTrigger("Attack Trigger");
        gameManagerScript.SEprocess8 = true;
        Invoke(nameof(DelayMethod6), 1f);
    }

    void DelayMethod5(){
        gameManagerScript.process9 = true;
    }

    void DelayMethod6(){
        gameManagerScript.SEprocess9 = true;
    }
}
