using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBehaviourScript : MonoBehaviour
{
    public Image redPanel;
    public Image bluePanel;
    public Image yellowPanel;
    public Image greenPanel;
    public Image redPanel2;
    public Image bluePanel2;
    public Image yellowPanel2;
    public Image greenPanel2;
    public Image redAllow;
    public Image redAllow2;
    public Image blueAllow;
    public Image blueAllow2;
    public Image yellowAllow;
    public Image yellowAllow2;
    public Image greenAllow;
    public Image greenAllow2;
    private float time;
    private float longTapTime;
    private bool judge;
    private int cnt;
    private GameManagerScript gameManagerScript;
    private bool judge2;
    public int rep;
    public bool judge3;
    private bool judge4;
    void Start()
    {
        time = 0f;
        redAllow.fillAmount = 0f;
        longTapTime = 1f;
        cnt = 0;
        gameManagerScript = GetComponent<GameManagerScript>();
        judge2 = false;
        judge3 = false;
        rep = 0;
    }

    void Update()
    {
        if (gameManagerScript.process4 == true){
            Invoke(nameof(DelayMethod1), 2f);
        }

        if (gameManagerScript.process5 == true)
        {
            Invoke(nameof(DelayMethod2), 1f);
            if(judge2 == true){
                redPanel.enabled = false;
                redPanel2.enabled = true;
                bluePanel.enabled = false;
                bluePanel2.enabled = true;
                yellowPanel.enabled = false;
                yellowPanel2.enabled = true;
                greenPanel.enabled = false;
                greenPanel2.enabled = true;

                judge2 = false;
                gameManagerScript.process5 = false;
                gameManagerScript.process6 = true;
            }
        }

        if(gameManagerScript.process7 == true){
            redPanel2.enabled = false;
            bluePanel2.enabled = false;
            yellowPanel2.enabled = false;
            greenPanel2.enabled = false;
            redAllow.enabled = false;
            redAllow2.enabled = false;
            blueAllow.enabled = false;
            blueAllow2.enabled = false;
            yellowAllow.enabled = false;
            yellowAllow2.enabled = false;
            greenAllow.enabled = false;
            greenAllow2.enabled = false;
        }

        if(gameManagerScript.process6 == true){
            if((Input.GetKeyDown(KeyCode.Z) || gameManagerScript.poses == 5) && cnt != 1){
                redAllow.enabled = true;
                redAllow2.enabled = true;
                blueAllow.enabled = false;
                blueAllow2.enabled = false;
                yellowAllow.enabled = false;
                yellowAllow2.enabled = false;
                greenAllow.enabled = false;
                greenAllow2.enabled = false;
                if(judge == false) judge = true;
                if(judge == true){
                    redAllow2.fillAmount = 0f;
                    blueAllow2.fillAmount = 0f;
                    yellowAllow2.fillAmount = 0f;
                    greenAllow2.fillAmount = 0f;
                    time = 0f;
                }
                cnt = 1;
            }

            if((Input.GetKeyDown(KeyCode.X) || gameManagerScript.poses == 6) && cnt != 2){
                redAllow.enabled = false;
                redAllow2.enabled = false;
                blueAllow.enabled = true;
                blueAllow2.enabled = true;
                yellowAllow.enabled = false;
                yellowAllow2.enabled = false;
                greenAllow.enabled = false;
                greenAllow2.enabled = false;
                if(judge == false) judge = true;
                if(judge == true){
                    redAllow2.fillAmount = 0f;
                    blueAllow2.fillAmount = 0f;
                    yellowAllow2.fillAmount = 0f;
                    greenAllow2.fillAmount = 0f;
                    time = 0f;
                }
                cnt = 2;
            }

            if((Input.GetKeyDown(KeyCode.C) || gameManagerScript.poses == 7) && cnt != 3){
                redAllow.enabled = false;
                redAllow2.enabled = false;
                blueAllow.enabled = false;
                blueAllow2.enabled = false;
                yellowAllow.enabled = true;
                yellowAllow2.enabled = true;
                greenAllow.enabled = false;
                greenAllow2.enabled = false;
                if(judge == false) judge = true;
                if(judge == true){
                    redAllow2.fillAmount = 0f;
                    blueAllow2.fillAmount = 0f;
                    yellowAllow2.fillAmount = 0f;
                    greenAllow2.fillAmount = 0f;
                    time = 0f;
                }
                cnt = 3;
            }

            if((Input.GetKeyDown(KeyCode.V) || gameManagerScript.poses == 8) && cnt != 4){
                redAllow.enabled = false;
                redAllow2.enabled = false;
                blueAllow.enabled = false;
                blueAllow2.enabled = false;
                yellowAllow.enabled = false;
                yellowAllow2.enabled = false;
                greenAllow.enabled = true;
                greenAllow2.enabled = true;
                if(judge == false) judge = true;
                if(judge == true){
                    redAllow2.fillAmount = 0f;
                    blueAllow2.fillAmount = 0f;
                    yellowAllow2.fillAmount = 0f;
                    greenAllow2.fillAmount = 0f;
                    time = 0f;
                }
                cnt = 4;
            }
        }

        if(judge == true){
            time += Time.deltaTime / 6;
            redAllow2.fillAmount = time / longTapTime;
            blueAllow2.fillAmount = time / longTapTime;
            yellowAllow2.fillAmount = time / longTapTime;
            greenAllow2.fillAmount = time / longTapTime;
        }

        TimeBehaviourScript TimeBehaviourScript = GetComponent<TimeBehaviourScript>();

        if(gameManagerScript.process6 == true){
            if(redAllow2.fillAmount == 1f || blueAllow2.fillAmount == 1f || yellowAllow2.fillAmount == 1f || greenAllow2.fillAmount == 1f || (TimeBehaviourScript.TimerNum <= 0.01f && TimeBehaviourScript.TimerNum >= -0.01f)){
                if(judge3 == false){
                    rep = cnt;
                    redAllow2.fillAmount = 0f;
                    blueAllow2.fillAmount = 0f;
                    yellowAllow2.fillAmount = 0f;
                    greenAllow2.fillAmount = 0f;
                    time = 0f;
                    judge = false;
                    redAllow.enabled = false;
                    redAllow2.enabled = false;
                    blueAllow.enabled = false;
                    blueAllow2.enabled = false;
                    yellowAllow.enabled = false;
                    yellowAllow2.enabled = false;
                    greenAllow.enabled = false;
                    greenAllow2.enabled = false;
                    gameManagerScript.process6 = false;
                    judge3 = true;
                    cnt = 0;
                }
            }
        }

        if(gameManagerScript.process4 == true) judge4 = false;
    }

    void DelayMethod1(){
        gameManagerScript.process4 = false;
        redPanel.enabled = true;
        bluePanel.enabled = true;
        yellowPanel.enabled = true;
        greenPanel.enabled = true;
        if(judge4 == false){
            Invoke(nameof(DelayMethod3), 2f);
        }
    }

    void DelayMethod2(){
        judge2 = true;
        gameManagerScript.judge5 = true;
    }

    void DelayMethod3(){
        gameManagerScript.process5 = true;
        judge4 = true;
    }
}
