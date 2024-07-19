using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using TMPro;

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
    public bool bgmprocess1;
    public bool bgmprocess2;
    public bool bgmprocess3;
    public bool bgmprocess4;
    public bool Stopbgmprocess1;
    public bool Stopbgmprocess2;
    public bool Stopbgmprocess3;
    public bool timebgmprocess1;
    public bool SEprocess1;
    public bool SEprocess2;
    public bool SEprocess3;
    public bool SEprocess4;
    public bool SEprocess5;
    public bool SEprocess6;
    public bool SEprocess7;
    public bool SEprocess8;
    public bool SEprocess9;
    public bool SEprocess10;
    public bool SEprocess11;
    public bool SEprocess12;
    public bool SEprocess13;
    public bool SEprocess14;
    public bool SEprocess15;
    public bool probprocess;
    public bool SucceedJudge;
    public int ans;
    public bool isCollect;
    public int n;
    public int CollectCnt;
    public int CharaCnt;
    public bool DestSign;
    public string prob;
    public string ansprob;
    public GameObject target;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;
    public GameObject target5;
    public GameObject camera;
    private PanelBehaviourScript panelBehaviourScript;
    private TimeBehaviourScript timeBehaviourScript;
    private HealthBehaviourScript healthBehaviourScript;
    public SplineAnimate splineAnimate;
    private float angle = 180f;
    private Vector3 axis = Vector3.up;
    private float interpolant = 0.05f;
    private Quaternion targetRot;
    private bool judge4;
    private bool startjudge;
    private int cnt2;
    private bool firstRotationComplete = false;
    public bool Attackjudge;
    public int poses;
    private bool movejudge;
    public bool clear;
    private bool firework;
    private bool bgmjudge;
    public bool judge5;

    void Start()
    {
        panelBehaviourScript = GetComponent<PanelBehaviourScript>();
        timeBehaviourScript = GetComponent<TimeBehaviourScript>();
        healthBehaviourScript = GetComponent<HealthBehaviourScript>();
        cnt = 0;
        n = 1;
        CollectCnt = 0;
        CharaCnt = 1;

        Debug.Log(TitleBehaviourScript.cnt);
    }

    void Update()
    {
        if((Input.GetKeyDown(KeyCode.I) || poses == 1) && startjudge == false){
            process1 = true;
            startjudge = true;
        }

        if(process2 == true && CharaCnt == 1){
            GameObject tmp_N = Resources.Load<GameObject>("Characters/chu-o-ji_Motion_Magic_All");
            GameObject Nomal = Instantiate(tmp_N);
            process2 = false;
            SEprocess1 = true;
        }

        if(process2 == true && CharaCnt == 2){
            GameObject tmp_R = Resources.Load<GameObject>("Characters/chu-o-ji_Motion_Rock_All");
            GameObject Rock = Instantiate(tmp_R);
            process2 = false;
            SEprocess7 = true;
        }

        if(process2 == true && CharaCnt == 3){
            SEprocess14 = true;
            splineAnimate.enabled = false;
            Invoke(nameof(DelayMethod5), 3.5f);
            process2 = false;
            judge4 = true;

            targetRot = Quaternion.AngleAxis(angle, axis) * camera.transform.rotation;
        }

        if(judge4){
            camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, targetRot, interpolant);
            // if(Quaternion.Angle(camera.transform.rotation, targetRot) < 0.005f && cnt2 == 0){
            //     cnt2++;
            //     angle = 179f;
            //     axis = Vector3.down;
            //     targetRot = Quaternion.AngleAxis(angle, axis) * camera.transform.rotation;
            // }

            // if(Quaternion.Angle(camera.transform.rotation, targetRot) < 0.005f && cnt2 == 1){
            //     cnt2++;
            //     angle = 90f;
            //     axis = Vector3.down;
            //     interpolant = 0.05f;
            //     targetRot = Quaternion.AngleAxis(angle, axis) * camera.transform.rotation;
            // }
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
            GameObject Input1 = GameObject.Find("TinyExplosion(Clone)");

            Vector3 newPosition = Input1.transform.position;
            newPosition.x = target.transform.position.x;
            newPosition.z = target.transform.position.z;
            Input1.transform.position = newPosition;

            Invoke(nameof(DelayMethod2), 1f);
            SEprocess11 = true;
            process9 = false;
            if(CharaCnt < 4){
                Invoke(nameof(DelayMethod3), 2.5f);
            }else{
                process10 = true;
                SucceedJudge = true;
            }
        }

        if (process10 == true && SucceedJudge == true)
        {
            Invoke(nameof(DelayMethod6), 3f);

            if(movejudge == true){
                float rotationLerpSpeed = 0.005f;
                float positionLerpSpeed = 0.005f;
                Quaternion targetRotation = Quaternion.Euler(90, 0, 0);
                Vector3 targetPosition = new Vector3(-35f, 40f, -28f);
                camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, targetRotation, rotationLerpSpeed);
                camera.transform.position = Vector3.Lerp(camera.transform.position, targetPosition, positionLerpSpeed);

                if (Vector3.Distance(camera.transform.position, targetPosition) < 20f && firework == false)
                {
                    GameObject tmp_Perticle1 = Resources.Load<GameObject>("Characters/FireWork");
                    GameObject Perticle1 = Instantiate(tmp_Perticle1);
                    firework = true;
                }
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
        if(CharaCnt == 2) Stopbgmprocess1 = true;
        if(CharaCnt == 3) Stopbgmprocess2 = true;
        if(CharaCnt == 4) Stopbgmprocess3 = true;
    }

    void DelayMethod3(){
        process1 = true;
    }

    void DelayMethod4(){
        SEprocess12 = true;
    }

    void DelayMethod5(){
        GameObject tmp_M = Resources.Load<GameObject>("Characters/chu-o-ji_Motion_Muscle_All");
        GameObject Muscle = Instantiate(tmp_M);
        Invoke(nameof(DelayMethod4), 0.4f);
        judge4 = false;
    }

    void DelayMethod6(){
        movejudge = true;
        clear = true;
        GameObject Input1 = GameObject.Find("Clear");
        Renderer renderer = Input1.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = true;
        }

        if(bgmjudge == false){
            Invoke(nameof(DelayMethod7), 2f);
            bgmjudge = true;
        }
    }

    void DelayMethod7(){
        bgmprocess4 = true;
    }
}
