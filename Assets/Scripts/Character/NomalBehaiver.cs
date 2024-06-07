using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalBehaiver : MonoBehaviour
{
    Animator animator;
    int cnt;
    void Start()
    {
        animator = GetComponent<Animator>();
        cnt = 0;
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            animator.SetTrigger("Attack Trigger");
            Invoke(nameof(DelayMethod1), 0.6f);
        }

        if(Input.GetKeyDown(KeyCode.D)){
            animator.SetTrigger("Damaged Trigger");
            cnt++;
        }

        if(Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.P)){
            Destroy(this.gameObject);
            // GameObject Input1 = GameObject.Find("MajicCircle(Clone)");
            // Input1.name = "MajicCircle1";
            // Destroy(GameObject.Find("MajicCircle1"));
        }

        if(cnt > 2){
            Invoke(nameof(DelayMethod2), 0.3f);
        }
    }

    void DelayMethod1(){
        GameObject tmp = Resources.Load<GameObject>("MajicBall");
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
    }
}
