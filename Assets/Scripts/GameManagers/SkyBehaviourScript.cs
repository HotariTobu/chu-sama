using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBehaviourScript : MonoBehaviour
{
    public Material[] sky;
    private GameObject gameManager;
    private GameManagerScript gameManagerScript;
    private TextBehaviourScript textBehaviourScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();
        textBehaviourScript = gameManager.GetComponent<TextBehaviourScript>();
        RenderSettings.skybox = sky[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagerScript.process1 == true){
            if(textBehaviourScript.cnt == 1){
                RenderSettings.skybox = sky[1];
            }
        }

        if(gameManagerScript.process1 == true){
            if(textBehaviourScript.cnt == 2){
                RenderSettings.skybox = sky[2];
            }
        }
    }
}
