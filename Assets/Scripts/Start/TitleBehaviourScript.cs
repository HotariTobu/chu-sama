using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleBehaviourScript : MonoBehaviour
{
    public GameObject panel;
    public Image Allow1;
    public Image Allow2;
    public Image Allow3;
    public Image Allow4;
    public Image gage;
    private float time1;
    private float time2;
    private float time3;
    private float longTapTime;
    private bool judge1;
    private bool judge2;
    private bool judge3;
    private Vector3 targetPos;
    private bool isMoving;
    public float moveDuration = 0.5f; // 移動にかかる時間
    private float moveTime; // 移動の経過時間
    public static int cnt = 1;
    public AudioClip sound1;
    public AudioClip sound2;
    AudioSource audioSource;
    public int poses;
    private Vector3 first;
    private Vector3 first1;
    private Vector3 first2;
    private Vector3 first3;
    private Vector3 first4;
    private Vector3 first5;
    private Vector3 first6;
    private Vector3 first7;


    // Start is called before the first frame update
    void Start()
    {
        Allow1.fillAmount = 0f;
        Allow2.fillAmount = 0f;
        gage.fillAmount = 0f;
        longTapTime = 1f;
        time1 = 0f;
        time2 = 0f;
        targetPos = panel.transform.position;
        isMoving = false;
        moveTime = 0f;
        cnt = 1;
        audioSource = GetComponent<AudioSource>();
        GameObject Input1 = GameObject.Find("chu-o-ji_Motion_Magic_All");
        first = Input1.transform.position;
        GameObject Input2 = GameObject.Find("left");
        first1 = Input2.transform.position;
        GameObject Input3 = GameObject.Find("right");
        first2 = Input3.transform.position;
        GameObject Input4 = GameObject.Find("maru");
        first3 = Input4.transform.position;
        GameObject Input5 = GameObject.Find("Y");
        first4 = Input5.transform.position;
        GameObject Input6 = GameObject.Find("M");
        first5 = Input6.transform.position;
        GameObject Input7 = GameObject.Find("C");
        first6 = Input7.transform.position;
        GameObject Input8 = GameObject.Find("A");
        first7 = Input8.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(cnt == 1){
            Allow1.enabled = false;
            Allow2.enabled = true;
            Allow3.enabled = false;
            Allow4.enabled = true;
        }else if(cnt == 3 || cnt == 4){
            Allow1.enabled = true;
            Allow2.enabled = false;
            Allow3.enabled = true;
            Allow4.enabled = false;
        }
        else{
            Allow1.enabled = true;
            Allow2.enabled = true;
            Allow3.enabled = true;
            Allow4.enabled = true;
        }

        if(cnt == 1){
            GameObject Input1 = GameObject.Find("chu-o-ji_Motion_Magic_All");
            Input1.transform.position = new Vector3(0f, 100f, 0f);
        }else{
            GameObject Input1 = GameObject.Find("chu-o-ji_Motion_Magic_All");
            Input1.transform.position = first;
        }

        if(cnt == 1){
            GameObject Input2 = GameObject.Find("left");
            Input2.transform.position = first1;
            GameObject Input3 = GameObject.Find("right");
            Input3.transform.position = first2;
            GameObject Input4 = GameObject.Find("maru");
            Input4.transform.position = first3;
            GameObject Input5 = GameObject.Find("Y");
            Input5.transform.position = first4;
            GameObject Input6 = GameObject.Find("M");
            Input6.transform.position = first5;
            GameObject Input7 = GameObject.Find("C");
            Input7.transform.position = first6;
            GameObject Input8 = GameObject.Find("A");
            Input8.transform.position = first7;
        }else{
            GameObject Input2 = GameObject.Find("left");
            Input2.transform.position = new Vector3(0f, 100f, 0f);
            GameObject Input3 = GameObject.Find("right");
            Input3.transform.position = new Vector3(0f, 100f, 0f);
            GameObject Input4 = GameObject.Find("maru");
            Input4.transform.position = new Vector3(0f, 100f, 0f);
            GameObject Input5 = GameObject.Find("Y");
            Input5.transform.position = new Vector3(0f, 100f, 0f);
            GameObject Input6 = GameObject.Find("M");
            Input6.transform.position = new Vector3(0f, 100f, 0f);
            GameObject Input7 = GameObject.Find("C");
            Input7.transform.position = new Vector3(0f, 100f, 0f);
            GameObject Input8 = GameObject.Find("A");
            Input8.transform.position = new Vector3(0f, 100f, 0f);
        }

        if(judge1)
        {
            time1 += Time.deltaTime / 2;
            Allow1.fillAmount = time1 / longTapTime;

            if(Allow1.fillAmount >= 1f)
            {
                judge1 = false;
                Allow1.fillAmount = 0f;
                time1 = 0f;
                targetPos += new Vector3(25f, 0f, 0f); // 左に移動
                isMoving = true;
                moveTime = 0f;
                cnt--;
                audioSource.PlayOneShot(sound1);
            }
        }

        if(judge2)
        {
            time2 += Time.deltaTime / 2;
            Allow2.fillAmount = time2 / longTapTime;

            if(Allow2.fillAmount >= 1f)
            {
                judge2 = false;
                Allow2.fillAmount = 0f;
                time2 = 0f;
                targetPos += new Vector3(-25f, 0f, 0f); // 右に移動
                isMoving = true;
                moveTime = 0f;
                cnt++;
                audioSource.PlayOneShot(sound1);
            }
        }

        if(judge3){
            time3 += Time.deltaTime / 2;
            gage.fillAmount = time3 / longTapTime;
            if(gage.fillAmount >= 1f)
            {
                audioSource.PlayOneShot(sound2);
                judge3 = false;
                gage.fillAmount = 0f;
                time3 = 0f;
                Invoke(nameof(DelayMethod1), 1f);
            }
        }

        if(Input.GetKeyDown(KeyCode.A) || poses == 1){
            judge1 = true;
        }

        if(Input.GetKeyDown(KeyCode.D) || poses == 2){
            judge2 = true;
        }

        if(cnt == 2 || cnt == 3){
            if(Input.GetKeyDown(KeyCode.S) || poses == 3){
                judge3 = true;
            }

            if(Input.GetKeyUp(KeyCode.S)){
                judge3 = false;
                time3 = 0;
                gage.fillAmount = 0;
            }
        }

        if(Input.GetKeyUp(KeyCode.A)){
            judge1 = false;
            time1 = 0;
            Allow1.fillAmount = 0;
        }

        if(Input.GetKeyUp(KeyCode.D)){
            judge2 = false;
            time2 = 0;
            Allow2.fillAmount = 0;
        }

        // パネルを徐々に移動させる処理
        if (isMoving)
        {
            moveTime += Time.deltaTime;
            float t = moveTime / moveDuration;
            panel.transform.position = Vector3.Lerp(panel.transform.position, targetPos, t);

            if (t >= 1f)
            {
                panel.transform.position = targetPos;
                isMoving = false;
            }
        }
    }

    void DelayMethod1(){
        SceneManager.LoadScene("Sample_005339_08932_25_14");
    }

}