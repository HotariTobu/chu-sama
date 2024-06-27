using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehaviourScript : MonoBehaviour
{
    public int health;
    public int NumOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Image panel;
    private GameManagerScript gameManagerScript;
    private TextBehaviourScript textBehaviourScript;

    void Start()
    {
        gameManagerScript = GetComponent<GameManagerScript>();
        textBehaviourScript = GetComponent<TextBehaviourScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagerScript.process8 == true && gameManagerScript.isCollect == false){
            if(health > 0){
                Invoke(nameof(DelayMethod1), 2.4f);
                Invoke(nameof(DelayMethod2), 3f);
            }
        }

        if(health > NumOfHearts){
            health = NumOfHearts;
        }

        for(int i = 0; i < hearts.Length; i++){
            if(i < health){
                hearts[i].sprite = fullHeart;
            }else{
                hearts[i].sprite = emptyHeart;
            }

            if(i < NumOfHearts){
                hearts[i].enabled = true;
            }else{
                hearts[i].enabled = false;
            }
        }
    }

    void DelayMethod1(){
        health--;
        panel.enabled = true;
    }

    void DelayMethod2(){
        if(health > 0){
            panel.enabled = false;
        }
        Invoke(nameof(DelayMethod3), 1f);
        Invoke(nameof(DelayMethod4), 4f);
        // gameManagerScript.process9 = true;
    }

    void DelayMethod3(){
        gameManagerScript.process910 = true;
    }

    void DelayMethod4(){
        gameManagerScript.process910 = false;
        textBehaviourScript.TextsM.enabled = false;
        gameManagerScript.process9 = true;
    }
}
