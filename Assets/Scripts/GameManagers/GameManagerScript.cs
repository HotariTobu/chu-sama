using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private int cnt;
    public bool process1;
    public bool process2;
    public bool process3;
    public bool process4;
    public bool process5;
    public bool process6;
    public bool process7;
    public bool process8;
    public bool process9;
    public bool process910;
    public bool process10;
    public bool SucceedJudge;
    public int ans = 1;
    public bool isCollect;
    public int n;
    public int CollectCnt;
    public int CharaCnt;
    public bool DestSign;
    private PanelBehaviourScript panelBehaviourScript;
    private TimeBehaviourScript timeBehaviourScript;
    private HealthBehaviourScript healthBehaviourScript;

    void Start()
    {
        panelBehaviourScript = GetComponent<PanelBehaviourScript>();
        timeBehaviourScript = GetComponent<TimeBehaviourScript>();
        healthBehaviourScript = GetComponent<HealthBehaviourScript>();
        cnt = 0;
        process1 = false;
        process2 = false;
        process3 = false;
        process4 = false;
        process5 = false;
        process6 = false;
        process7 = false;
        process8 = false;
        process9 = false;
        process910 = false;
        process10 = false;
        n = 1;
        CollectCnt = 0;
        CharaCnt = 1;
        DestSign = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
            process1 = true;
        }

        if(process2 == true && CharaCnt == 1){
            GameObject tmp_N = Resources.Load<GameObject>("Characters/chu-o-ji_Motion_Magic_All");
            GameObject Nomal = Instantiate(tmp_N);
            process2 = false;
        }

        if(process2 == true && CharaCnt == 2){
            GameObject tmp_R = Resources.Load<GameObject>("Characters/chu-o-ji_Motion_Rock_All");
            GameObject Rock = Instantiate(tmp_R);
            process2 = false;
        }

        if(process2 == true && CharaCnt == 3){
            GameObject tmp_M = Resources.Load<GameObject>("Characters/chu-o-ji_Motion_Muscle_All");
            GameObject Muscle = Instantiate(tmp_M);
            process2 = false;
        }

        if(healthBehaviourScript.health > 0){
            if(process9 == true && CollectCnt < 2){
                panelBehaviourScript.judge3 = false;
                timeBehaviourScript.judge = false;
                process9 = false;
                process3 = true;
            }
        }

        if(panelBehaviourScript.rep != 0){
            Invoke(nameof(DelayMethod1), 1f);
            process7 = true;
        }

        if(process9 == true && CollectCnt == 2){
            panelBehaviourScript.judge3 = false;
            timeBehaviourScript.judge = false;
            CollectCnt = 0;
            DestSign = true;
            CharaCnt++;
            GameObject tmp_Perticle1 = Resources.Load<GameObject>("Characters/TinyExplosion");
            GameObject Perticle1 = Instantiate(tmp_Perticle1);
            Invoke(nameof(DelayMethod2), 1f);
            process9 = false;
            if(CharaCnt < 4){
                Invoke(nameof(DelayMethod3), 2.5f);
            }else{
                process10 = true;
                SucceedJudge = true;
            }
        }

        if(healthBehaviourScript.health == 0){
            process10 = true;
            SucceedJudge = false;
        }
    }

    void DelayMethod1(){
        process7 = false;
        process8 = true;
    }

    void DelayMethod2(){
        GameObject Input1 = GameObject.Find("TinyExplosion(Clone)");
        Input1.name = "TinyExplosion1";
        Destroy(GameObject.Find("TinyExplosion1"));
    }

    void DelayMethod3(){
        process1 = true;
    }
}
