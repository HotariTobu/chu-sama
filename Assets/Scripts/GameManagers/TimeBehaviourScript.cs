using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeBehaviourScript : MonoBehaviour
{
    public float TimerNum = 15;
    public TextMeshProUGUI TimerText;
    public GameObject Timer;
    public RectTransform Parent;
    public RectTransform Children;
    private bool movedr = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 childPos = Children.position;
        Vector3 parentPos = Parent.position;
        float distance = parentPos.x - childPos.x;

        if(Input.GetKeyDown(KeyCode.G)){
            childPos.z += 18f;
            Children.position = childPos;
        }

        if (TimerNum > 0)
        {
            TimerNum -= Time.deltaTime;
            TimerText.text = ((int)TimerNum).ToString();
        }

        if (TimerNum < 10 && distance < 5 && !movedr)
        {
            childPos.x += 18f;
            Children.position = childPos;
            movedr = true; 
        }

        if(Input.GetKeyDown(KeyCode.W)){
            TimerNum = 16;
            TimerText.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            TimerNum = 16;
            TimerText.enabled = false;
            movedr = false;
            childPos.x = parentPos.x;
            Children.position = childPos;
        }
    }
}