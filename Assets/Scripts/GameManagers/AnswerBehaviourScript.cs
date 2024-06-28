using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerBehaviourScript : MonoBehaviour
{
    private bool judge1;
    private bool judge2;
    private bool judge3;
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
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagerScript.process7 == true && panelBehaviourScript.rep != 0){
            if(panelBehaviourScript.rep == gameManagerScript.ans){
                gameManagerScript.SEprocess3 = true;
                panelBehaviourScript.rep = 0;
                judge1 = true;
                GameObject Input1 = Resources.Load<GameObject>("Characters/Circle");

                if (Input1 != null)
                {
                    GameObject Tmp = Instantiate(Input1);
                    Tmp.name = "circle";
                    circle = Tmp;
                    judge3 = true;

                    if (circle != null)
                    {
                        first1 = circle.transform.position;
                    }
                }
                gameManagerScript.isCollect = true;
                gameManagerScript.CollectCnt++;
                gameManagerScript.n++;
            }else{
                gameManagerScript.SEprocess4 = true;
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
            Vector3 newPosition = circle.transform.position;
            newPosition.x = gameManagerScript.target2.transform.position.x;
            newPosition.z = gameManagerScript.target2.transform.position.z;
            circle.transform.position = newPosition;

            Vector3 directionToFace = gameManagerScript.camera.transform.position - circle.transform.position;
            directionToFace.y = 0; // Keep only horizontal rotation
            circle.transform.rotation = Quaternion.LookRotation(directionToFace);

            if (circle.transform.position.y > 0.85)
            {
                circle.transform.position += new Vector3(0f, -0.2f, 0f);
            }else{
                Invoke(nameof(DelayMethod2), 2f);
            }
        }

        if (cross != null)
        {
            Vector3 newPosition = cross.transform.position;
            newPosition.x = gameManagerScript.target2.transform.position.x;
            newPosition.z = gameManagerScript.target2.transform.position.z;
            cross.transform.position = newPosition;

            Vector3 directionToFace = gameManagerScript.camera.transform.position - cross.transform.position;
            directionToFace.y = 0; // Keep only horizontal rotation
            cross.transform.rotation = Quaternion.LookRotation(directionToFace);

            if (cross.transform.position.y > 0.85)
            {
                cross.transform.position += new Vector3(0f, -0.2f, 0f);
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