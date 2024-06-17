using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBehaviourScript : MonoBehaviour
{
    public Material[] sky;
    private GameObject gameManager;
    private GameManagerScript gameManagerScript;
    private TextBehaviourScript textBehaviourScript;
    private bool skyjudge1;
    private bool skyjudge2;
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
        if(textBehaviourScript.SkyNum == 2 && skyjudge1 == false){
            RenderSettings.skybox = sky[1];
            skyjudge1 = true;
        }

        if(textBehaviourScript.SkyNum == 3 && skyjudge2 == false){
            RenderSettings.skybox = sky[2];
            skyjudge2 = true;
        }
    }
}
