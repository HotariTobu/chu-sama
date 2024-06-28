using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject StartlightObject;
    [SerializeField] GameObject NextlightObject;
    [SerializeField] GameObject SpotlightObject;
    private Light startlight;
    private Light nextlight;
    private Light spotlight;
    private GameObject gameManager;
    private TextBehaviourScript textBehaviourScript;
    private bool skyjudge1;
    private bool skyjudge2;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        startlight = StartlightObject.GetComponent<Light>();
        nextlight = NextlightObject.GetComponent<Light>();
        spotlight = SpotlightObject.GetComponent<Light>();
        textBehaviourScript = gameManager.GetComponent<TextBehaviourScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(textBehaviourScript.SkyNum == 2 && skyjudge1 == false){
            startlight.enabled = false;
            nextlight.enabled = true;
            skyjudge1 = true;
        }

        if(textBehaviourScript.SkyNum == 3 && skyjudge2 == false){
            nextlight.enabled = false;
            spotlight.enabled = true;
            skyjudge2 = true;
        }
    }
}
