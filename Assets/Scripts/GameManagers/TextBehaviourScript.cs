using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextBehaviourScript : MonoBehaviour
{
    public GameObject Texts;
    private TextMeshProUGUI TextsM;
    private int cnt;
    // Start is called before the first frame update
    void Start()
    {
        TextsM = Texts.GetComponent<TextMeshProUGUI>();
        cnt = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)){
            if(cnt == 1){
                TextsM.text = "2nd Stage";
                cnt++;
            }
            if(cnt == 2){
                TextsM.text = "3rd Stage";
            }
        }
    }
}
