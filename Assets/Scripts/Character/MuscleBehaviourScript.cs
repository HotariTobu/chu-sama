using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuscleBehaviourScript : MonoBehaviour
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
        Invoke(nameof(DelayMethod1), 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagerScript.process8 == true && gameManagerScript.isCollect == false){
            gameManagerScript.process8 = false;
            Invoke(nameof(DelayMethod4), 1.5f);
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
        GameObject tmp_Perticle1 = Resources.Load<GameObject>("Characters/EarthCrack");
        GameObject Perticle1 = Instantiate(tmp_Perticle1);
    }

    void DelayMethod2(){
        Destroy(this.gameObject);
    }

    void DelayMethod3(){
        animator.SetTrigger("Damaged Trigger");
        Invoke(nameof(DelayMethod5), 1f);
    }

    void DelayMethod4(){
        animator.SetTrigger("Attack Trigger");
        Invoke(nameof(DelayMethod6), 0.8f);

    }

    void DelayMethod5(){
        gameManagerScript.process9 = true;
    }

    void DelayMethod6(){
        GameObject tmp_Perticle1 = Resources.Load<GameObject>("Characters/ScreenCrack");
        GameObject Perticle1 = Instantiate(tmp_Perticle1);
        GameObject Input1 = GameObject.Find("Main Camera");
        Vector3 tmp = new Vector3(0f, 0f, 0.5f);
        Perticle1.transform.position = Input1.transform.position + tmp;
    }
}
