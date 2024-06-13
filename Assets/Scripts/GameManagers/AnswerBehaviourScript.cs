using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerBehaviourScript : MonoBehaviour
{
    private bool judge1;
    private bool judge2;
    private Vector3 first1;
    private GameObject circle;
    private Vector3 first2;
    private GameObject cross;
    private GameManagerScript gameManagerScript;
    private PanelBehaviourScript panelBehaviourScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GetComponent<GameManagerScript>();
        panelBehaviourScript = GetComponent<PanelBehaviourScript>();
        judge1 = false;
        judge2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagerScript.process7 == true && panelBehaviourScript.rep != 0){
            if(panelBehaviourScript.rep == gameManagerScript.ans){
                panelBehaviourScript.rep = 0;
                judge1 = true;
                GameObject Input1 = Resources.Load<GameObject>("Characters/Circle");

                if (Input1 != null)
                {
                    GameObject Tmp = Instantiate(Input1);
                    Tmp.name = "circle";
                    circle = Tmp;

                    if (circle != null)
                    {
                        first1 = circle.transform.position;
                    }
                }
                gameManagerScript.isCollect = true;
                gameManagerScript.CollectCnt++;
                gameManagerScript.n++;
            }else{
                panelBehaviourScript.rep = 0;
                judge1 = true;
                GameObject Input1 = Resources.Load<GameObject>("Characters/Cross");

                if (Input1 != null)
                {
                    GameObject Tmp = Instantiate(Input1);
                    Tmp.name = "cross";
                    cross = Tmp;

                    if (cross != null)
                    {
                        first2 = cross.transform.position;
                    }
                }
                gameManagerScript.isCollect = false;
                gameManagerScript.n++;
            }
        }

        if (circle != null)
        {
            if (judge1 == true && circle.transform.position.y > 3)
            {
                circle.transform.position += new Vector3(0f, -0.15f, 0f);
            }

            if (circle.transform.position.y <= 3)
            {
                if (circle.transform.position.z < 10)
                {
                    Invoke(nameof(DelayMethod1), 2f);
                }
                else
                {
                    judge1 = false;
                    Invoke(nameof(DelayMethod2), 2f);
                    circle.transform.position = first1;
                }
            }

            if (judge2 == true && circle.transform.position.y <= 3)
            {
                circle.transform.position += new Vector3(0f, 0f, 0.5f);
            }
        }

        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     GameObject Input1 = Resources.Load<GameObject>("Characters/Cross");

        //     if (Input1 != null)
        //     {
        //         GameObject Tmp = Instantiate(Input1);
        //         Tmp.name = "cross";
        //         cross = Tmp;

        //         if (cross != null)
        //         {
        //             first2 = cross.transform.position;
        //         }
        //     }
        // }

        if (cross != null)
        {
            if (cross.transform.position.y > 3)
            {
                cross.transform.position += new Vector3(0f, -0.15f, 0f);
            }else{
                Invoke(nameof(DelayMethod3), 2f);
            }
        }
    }

    void DelayMethod1()
    {
        judge2 = true;
    }

    void DelayMethod2()
    {
        judge2 = false;
        Destroy(GameObject.Find("circle"));
    }

    void DelayMethod3()
    {
        Destroy(GameObject.Find("cross"));
    }
}