using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextBehaviourScript : MonoBehaviour
{
    public GameObject Texts;
    public TextMeshProUGUI TextsM;
    public int cnt;
    public GameObject q1;
    public GameObject q2;
    public GameObject q3;
    public GameObject q4;
    private TextMeshProUGUI qt1;
    private TextMeshProUGUI qt2;
    private TextMeshProUGUI qt3;
    private TextMeshProUGUI qt4;
    private float objScale;
    private GameManagerScript gameManagerScript;
    public int SkyNum;
    // Start is called before the first frame update
    void Start()
    {
        cnt = 0;
        gameManagerScript = GetComponent<GameManagerScript>();
        qt1 = q1.GetComponent<TextMeshProUGUI>();
        qt2 = q2.GetComponent<TextMeshProUGUI>();
        qt3 = q3.GetComponent<TextMeshProUGUI>();
        qt4 = q4.GetComponent<TextMeshProUGUI>();
        objScale = 1.0f;
        SkyNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagerScript.process1 == true){
            if(cnt == 0){
                gameManagerScript.bgmprocess1 = true;
                TextsM.enabled = true;
                cnt++;
                Invoke(nameof(DelayMethod1), 2f);
                gameManagerScript.process1 = false;
            }
        }

        if(gameManagerScript.process1 == true){
            if(cnt == 1){
                gameManagerScript.bgmprocess2 = true;
                TextsM.text = "2nd Stage";
                TextsM.enabled = true;
                cnt++;
                SkyNum++;
                Invoke(nameof(DelayMethod1), 2f);
                gameManagerScript.process1 = false;
            }
        }

        if(gameManagerScript.process1 == true){
            if(cnt == 2){
                gameManagerScript.bgmprocess3 = true;
                TextsM.text = "3rd Stage";
                TextsM.enabled = true;
                cnt++;
                SkyNum++;
                Invoke(nameof(DelayMethod1), 2f);
                gameManagerScript.process1 = false;
            }
        }

        if(gameManagerScript.process3 == true){
            Invoke(nameof(DelayMethod2), 2f);
            Invoke(nameof(DelayMethod3), 4f);
            gameManagerScript.process3 = false;
        }

        if(gameManagerScript.process4 == true){
            Invoke(nameof(DelayMethod5), 2f);
        }

        if(gameManagerScript.process6 == true){
            objScale+=0.001f;
            Texts.transform.localScale = new Vector3 (objScale, objScale, objScale);
        }

        if(gameManagerScript.process6 == false && objScale != 1f){
            objScale = 1f;
            Texts.transform.localScale = new Vector3 (objScale, objScale, objScale);
        }

        if(gameManagerScript.process7 == true){
            qt1.enabled = false;
            qt2.enabled = false;
            qt3.enabled = false;
            qt4.enabled = false;
            TextsM.enabled = false;
        }

        if(gameManagerScript.process910 == true){
            TextsM.text = "答え　"+gameManagerScript.ans.ToString();
            TextsM.enabled = true;
        }

        if(gameManagerScript.process10 == true){
            if(gameManagerScript.SucceedJudge == true){
                TextsM.text = "Clear!";
                TextsM.enabled = true;
            }else{
                TextsM.text = "You Died";
                TextsM.enabled = true;
            }
        }
    }

    void DelayMethod1(){
        gameManagerScript.process2 = true;
    }

    void DelayMethod2(){
        gameManagerScript.SEprocess2 = true;
        TextsM.text = "Q" + gameManagerScript.n.ToString();
        TextsM.enabled = true;
    }

    void DelayMethod3(){
        TextsM.text = "犬";
        gameManagerScript.process4 = true;
    }

    void DelayMethod5(){
        qt1.enabled = true;
        qt2.enabled = true;
        qt3.enabled = true;
        qt4.enabled = true;
    }
}
