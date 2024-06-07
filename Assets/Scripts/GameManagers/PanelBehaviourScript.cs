using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBehaviourScript : MonoBehaviour
{
    public Image Panel1;
    public Image Panel2;
    public Image Panel3;
    public Image Panel4;
    public RectTransform Parent;
    public RectTransform Children1;
    public RectTransform Children2;
    public RectTransform Children3;
    public RectTransform Children4;
    public Image Allow1;
    public Image Allow2;
    public RectTransform Allow_T1;
    public RectTransform Allow_T2;

    public Vector3 Pos1;
    public Vector3 Pos2;
    public Vector3 Pos3;
    public Vector3 Pos4;
    private float time;
    private float longTapTime;
    private bool judge;
    private int cnt;

    void Start()
    {
        Pos1 = Children1.position;
        Pos2 = Children2.position;
        Pos3 = Children3.position;
        Pos4 = Children4.position;
        time = 0f;
        Allow1.fillAmount = 0f;
        longTapTime = 1f;
        cnt = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)){
            Children1.position = Pos1;
            Children2.position = Pos2;
            Children3.position = Pos3;
            Children4.position = Pos4;
            Panel1.enabled = true;
            Panel2.enabled = true;
            Panel3.enabled = true;
            Panel4.enabled = true;
        }

        Vector3 childPos1 = Children1.position;
        Vector3 childPos2 = Children2.position;
        Vector3 childPos3 = Children3.position;
        Vector3 childPos4 = Children4.position;
        Vector3 parentPos = Parent.position;

        Vector3[] corners = new Vector3[4];
        Parent.GetWorldCorners(corners);

        float parentLeftEdge = corners[0].x;
        float parentTopEdge = corners[1].y;
        float parentRightEdge = corners[2].x; 
        float parentBottomEdge = corners[0].y;

        if (Input.GetKeyDown(KeyCode.W))
        {
            float childWidth1 = Children1.rect.width * Children1.lossyScale.x;
            childPos1.x = parentLeftEdge + (childWidth1 / 2);
            Children1.position = childPos1;
            float childHeight1 = Children1.rect.height * Children1.lossyScale.y; 
            childPos1.y = parentTopEdge - (childHeight1 / 2);
            Children1.position = childPos1;

            float childHeight2 = Children2.rect.height * Children2.lossyScale.y; 
            childPos2.y = parentTopEdge - (childHeight2 / 2);
            Children2.position = childPos2;
            float childWidth2 = Children2.rect.width * Children2.lossyScale.x; 
            childPos2.x = parentRightEdge - (childWidth2 / 2);
            Children2.position = childPos2;

            float childHeight3 = Children3.rect.height * Children3.lossyScale.y; 
            childPos3.y = parentBottomEdge + (childHeight3 / 2);
            Children3.position = childPos3;
            float childWidth3 = Children3.rect.width * Children3.lossyScale.x; 
            childPos3.x = parentLeftEdge + (childWidth3 / 2);
            Children3.position = childPos3;

            float childWidth4 = Children4.rect.width * Children4.lossyScale.x; 
            childPos4.x = parentRightEdge - (childWidth4 / 2);
            Children4.position = childPos4;
            float childHeight4 = Children4.rect.height * Children4.lossyScale.y; 
            childPos4.y = parentBottomEdge + (childHeight4 / 2);
            Children4.position = childPos4;
        }

        if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)){
            Panel1.enabled = false;
            Panel2.enabled = false;
            Panel3.enabled = false;
            Panel4.enabled = false;
            Allow1.enabled = false;
            Allow2.enabled = false;
            Children1.position = Pos1;
            Children2.position = Pos2;
            Children3.position = Pos3;
            Children4.position = Pos4;
        }

        if(Input.GetKeyDown(KeyCode.Z)){
            Allow1.enabled = true;
            Allow2.enabled = true;
            Allow_T1.rotation = Quaternion.Euler(0, 0, 180);
            Allow_T2.rotation = Quaternion.Euler(0, 0, 180);
            Vector3 newPos = Children1.position;
            float childHeight = Children1.rect.height * Children1.lossyScale.y;
            float allowHeight = Allow_T1.rect.height * Allow_T1.lossyScale.y;
            newPos.y -= (childHeight / 2) + (allowHeight / 2);
            Allow_T1.position = newPos;
            Allow_T2.position = newPos;
            if(judge == false) judge = true;
            if(judge == true){
                Allow1.fillAmount = 0f;
                time = 0f;
            }
            cnt = 1;
        }

        if(Input.GetKeyDown(KeyCode.X)){
            Allow1.enabled = true;
            Allow2.enabled = true;
            Allow_T1.rotation = Quaternion.Euler(0, 0, 180);
            Allow_T2.rotation = Quaternion.Euler(0, 0, 180);
            Vector3 newPos = Children2.position;
            float childHeight = Children2.rect.height * Children2.lossyScale.y;
            float allowHeight = Allow_T1.rect.height * Allow_T1.lossyScale.y;
            newPos.y -= (childHeight / 2) + (allowHeight / 2);
            Allow_T1.position = newPos;
            Allow_T2.position = newPos;
            if(judge == false) judge = true;
            if(judge == true){
                Allow1.fillAmount = 0f;
                time = 0f;
            }
            cnt = 2;
        }

        if(Input.GetKeyDown(KeyCode.C)){
            Allow1.enabled = true;
            Allow2.enabled = true;
            Allow_T1.rotation = Quaternion.Euler(0, 0, 0);
            Allow_T2.rotation = Quaternion.Euler(0, 0, 0);
            Vector3 newPos = Children3.position;
            float childHeight = Children3.rect.height * Children3.lossyScale.y;
            float allowHeight = Allow_T1.rect.height * Allow_T1.lossyScale.y;
            newPos.y += (childHeight / 2) + (allowHeight / 2);
            Allow_T1.position = newPos;
            Allow_T2.position = newPos;
            if(judge == false) judge = true;
            if(judge == true){
                Allow1.fillAmount = 0f;
                time = 0f;
            }
            cnt = 3;
        }

        if(Input.GetKeyDown(KeyCode.V)){
            Allow1.enabled = true;
            Allow2.enabled = true;
            Allow_T1.rotation = Quaternion.Euler(0, 0, 0);
            Allow_T2.rotation = Quaternion.Euler(0, 0, 0);
            Vector3 newPos = Children4.position;
            float childHeight = Children4.rect.height * Children4.lossyScale.y;
            float allowHeight = Allow_T1.rect.height * Allow_T1.lossyScale.y;
            newPos.y += (childHeight / 2) + (allowHeight / 2);
            Allow_T1.position = newPos;
            Allow_T2.position = newPos;
            if(judge == false) judge = true;
            if(judge == true){
                Allow1.fillAmount = 0f;
                time = 0f;
            }
            cnt = 4;
        }

        if(judge == true){
            time += Time.deltaTime / 6;
            Allow1.fillAmount = time / longTapTime;
        }

        TimeBehaviourScript TimeBehaviourScript = GetComponent<TimeBehaviourScript>();

        if(Allow1.fillAmount == 1f || (TimeBehaviourScript.TimerNum <= 0.01f && TimeBehaviourScript.TimerNum >= -0.01f)){
            // Debug.Log(cnt);
            Allow1.fillAmount = 0f;
            time = 0f;
            judge = false;
            Allow1.enabled = false;
            Allow2.enabled = false;
        }
    }
}
