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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            if(health > 0){
                Invoke(nameof(DelayMethod1), 1f);
                Invoke(nameof(DelayMethod2), 1.7f);
            }
        }

        if(Input.GetKeyDown(KeyCode.I)){
            health++;
        }

        if(Input.GetKeyDown(KeyCode.P)){
            health++;
        }

        if(Input.GetKeyDown(KeyCode.O)){
            health++;
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
        panel.enabled = false;
    }
}
