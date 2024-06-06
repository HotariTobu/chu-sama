using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    int cnt;

    void Start()
    {
        cnt = 0;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
            GameObject tmp_N = Resources.Load<GameObject>("chu-o-ji_Motion_Magic_All");
            GameObject Nomal = Instantiate(tmp_N);
        }

        if(Input.GetKeyDown(KeyCode.P)){
            GameObject tmp_M = Resources.Load<GameObject>("chu-o-ji_Motion_Muscle_All");
            GameObject Muscle = Instantiate(tmp_M);
        }

        if(Input.GetKeyDown(KeyCode.O)){
            GameObject tmp_R = Resources.Load<GameObject>("chu-o-ji_Motion_Rock_All");
            GameObject Rock = Instantiate(tmp_R);
        }

        if(Input.GetKeyDown(KeyCode.D)){
            cnt++;
        }

        if(cnt > 2){
            GameObject tmp_Perticle1 = Resources.Load<GameObject>("TinyExplosion");
            GameObject Perticle1 = Instantiate(tmp_Perticle1);
            cnt = 0;
            Invoke(nameof(DelayMethod1), 1f);
        }
    }

    void DelayMethod1(){
        GameObject Input1 = GameObject.Find("TinyExplosion(Clone)");
        Input1.name = "TinyExplosion1";
        Destroy(GameObject.Find("TinyExplosion1"));
    }
}
