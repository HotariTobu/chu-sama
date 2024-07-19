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
    public bool judge = false;
    private GameManagerScript gameManagerScript;
    private PanelBehaviourScript panelBehaviourScript;

    void Start()
    {
        gameManagerScript = GetComponent<GameManagerScript>();
        panelBehaviourScript = GetComponent<PanelBehaviourScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 childPos = Children.position;
        Vector3 parentPos = Parent.position;
        float distance = parentPos.x - childPos.x;

        if (TimerNum > 0)
        {
            TimerNum -= Time.deltaTime;
            TimerText.text = ((int)TimerNum).ToString();
        }

        if (TimerNum < 10 && distance < 5 && !movedr)
        {
            childPos.x += 18f;
            // Children.position = childPos;
            movedr = true;
        }

        if(gameManagerScript.process5 == true){
            TimerNum = 16;
        }

        if(gameManagerScript.process6 == true && judge == false){
            judge = true;
            TimerNum = 16;
            TimerText.enabled = true;
            gameManagerScript.timebgmprocess1 = true;
        }

        if (gameManagerScript.process6 == true && judge == true)
        {
            Debug.Log($"a {TimerNum}");
            if (TimerNum < 0.00001)
            {
                panelBehaviourScript.rep = 5;
                Debug.Log("b");
            }
        }

        if (gameManagerScript.process7 == true)
        {
            TimerNum = 16;
            TimerText.enabled = false;
            movedr = false;
            childPos.x = parentPos.x;
            Children.position = childPos;
        }
    }
}