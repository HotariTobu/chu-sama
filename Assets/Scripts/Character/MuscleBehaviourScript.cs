using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuscleBehaviourScript : MonoBehaviour
{
    Animator animator;
    int cnt;
    void Start()
    {
        animator = GetComponent<Animator>();
        cnt = 0;
        Invoke(nameof(DelayMethod1), 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            animator.SetTrigger("Attack Trigger");
            Invoke(nameof(DelayMethod3), 1f);
        }

        if(Input.GetKeyDown(KeyCode.D)){
            animator.SetTrigger("Damaged Trigger");
            cnt++;
        }

        if(Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.I)){
            Destroy(this.gameObject);
        }

        if(cnt > 2){
            Invoke(nameof(DelayMethod2), 0.3f);
        }
    }

    void DelayMethod1(){
        GameObject tmp_Perticle1 = Resources.Load<GameObject>("Characters/EarthCrack");
        GameObject Perticle1 = Instantiate(tmp_Perticle1);
    }

    void DelayMethod2(){
        Destroy(this.gameObject);
    }

    void DelayMethod3(){
        GameObject tmp_Perticle1 = Resources.Load<GameObject>("Characters/ScreenCrack");
        GameObject Perticle1 = Instantiate(tmp_Perticle1);
        GameObject Input1 = GameObject.Find("Main Camera");
        Vector3 tmp = new Vector3(0f, 0f, 0.5f);
        Perticle1.transform.position = Input1.transform.position + tmp;
    }
}
