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
    // Start is called before the first frame update
    void Start()
    {
        cnt = 1;
    }

    // Update is called once per frame
    void Update()
    {
        GameManagerScript GameManagerScript = GetComponent<GameManagerScript>();
        if(GameManagerScript.process1 == true){
            TextsM.enabled = true;
        }

        if(Input.GetKeyDown(KeyCode.M)){
            if(cnt == 1){
                TextsM.text = "2nd Stage";
                Invoke(nameof(DelayMethod1), 2f);
            }
            if(cnt == 2){
                TextsM.text = "3rd Stage";
            }
        }
    }

    void DelayMethod1(){
        GameManagerScript.process2 = true;
        TextsM.enabled = false;
        cnt++;
    }
}
