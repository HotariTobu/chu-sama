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
    }

    // Update is called once per frame
    void Update()
    {
        if(cnt == 1){
            Allow1.enabled = false;
            Allow2.enabled = true;
            Allow3.enabled = false;
            Allow4.enabled = true;
        }else if(cnt == 2){
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

        if(Input.GetKeyDown(KeyCode.A)){
            judge1 = true;
        }

        if(Input.GetKeyDown(KeyCode.D)){
            judge2 = true;
        }

        if(Input.GetKeyDown(KeyCode.S)){
            judge3 = true;
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

        if(Input.GetKeyUp(KeyCode.S)){
            judge3 = false;
            time3 = 0;
            gage.fillAmount = 0;
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
        SceneManager.LoadScene("MahiroScene");
    }

}