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
    private GameManagerScript gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        cnt = 0;
        gameManagerScript = GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagerScript.process1 == true){
            if(cnt == 0){
                TextsM.enabled = true;
                cnt++;
                Invoke(nameof(DelayMethod1), 2f);
            }
        }

        // if(cnt == 1){
        //     TextsM.text = "2nd Stage";
        // }
        // if(cnt == 2){
        //     TextsM.text = "3rd Stage";
        // }
    }

    void DelayMethod1(){
        gameManagerScript.process2 = true;
        TextsM.enabled = false;
    }
}
