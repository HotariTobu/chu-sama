using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviourScript : MonoBehaviour
{
    Animator animator;
    int cnt;
    private GameObject gameManager;
    private GameManagerScript gameManagerScript;
    private HealthBehaviourScript healthBehaviourScript;
    GameObject Input1;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();
        healthBehaviourScript = gameManager.GetComponent<HealthBehaviourScript>();
        animator = GetComponent<Animator>();
        cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = this.transform.position;
        newPosition.x = gameManagerScript.target.transform.position.x;
        newPosition.z = gameManagerScript.target.transform.position.z;
        this.transform.position = newPosition;

        Vector3 directionToFace = gameManagerScript.camera.transform.position - transform.position;
        directionToFace.y = 0; // Keep only horizontal rotation
        transform.rotation = Quaternion.LookRotation(directionToFace);

        if(GameObject.Find("Stage1")){
            Input1 = GameObject.Find("Stage1");

            Vector3 newPosition2 = Input1.transform.position;
            newPosition2.x = gameManagerScript.target.transform.position.x;
            newPosition2.z = gameManagerScript.target.transform.position.z;
            Input1.transform.position = newPosition2;

            Vector3 directionToFace2 = gameManagerScript.camera.transform.position - Input1.transform.position;
            directionToFace2.y = 0; // Keep only horizontal rotation
            Input1.transform.rotation = Quaternion.LookRotation(directionToFace2);
        }

        if(gameManagerScript.process8 == true && gameManagerScript.isCollect == false){
            gameManagerScript.process8 = false;
            Invoke(nameof(DelayMethod4), 0.7f);
            Invoke(nameof(DelayMethod1), 2.1f);
        }

        if(gameManagerScript.process8 == true && gameManagerScript.isCollect == true){
            gameManagerScript.process8 = false;
            Invoke(nameof(DelayMethod3), 1.2f);
            cnt++;
        }

        if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.P)){
            Destroy(this.gameObject);
            GameObject Input1 = GameObject.Find("Stage1");
            Destroy(Input1);
        }

        if(gameManagerScript.DestSign == true){
            gameManagerScript.DestSign = false;
            Invoke(nameof(DelayMethod2), 0.3f);
        }
    }

    void DelayMethod1(){
        GameObject tmp = Resources.Load<GameObject>("Characters/Razer");
        GameObject RockAttack = Instantiate(tmp);
        GameObject Input1 = GameObject.Find("Razer(Clone)");
        Input1.transform.position = new Vector3(gameManagerScript.target.transform.position.x, 1f, gameManagerScript.target.transform.position.z);
        GameObject Input2 = GameObject.Find("Main Camera_akihabara");
        Vector3 direction = new Vector3(Input2.transform.position.x - this.gameObject.transform.position.x, Input2.transform.position.y - this.gameObject.transform.position.y, Input2.transform.position.z - this.gameObject.transform.position.z);
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up) * Quaternion.Euler(0f, 180f, 0f);
        Vector3 eulerAngles = targetRotation.eulerAngles;
        Vector3 Angles = new Vector3(-5f, 180f, 0f);
        Input1.transform.Rotate(eulerAngles + Angles);
    }

    void DelayMethod2(){
        Destroy(this.gameObject);
        healthBehaviourScript.health++;
        GameObject Input1 = GameObject.Find("Stage1");
        Destroy(Input1);
    }

    void DelayMethod3(){
        animator.SetTrigger("Damaged Trigger");
        gameManagerScript.SEprocess10 = true;
        GameObject tmp = Resources.Load<GameObject>("Characters/Slash1");
        GameObject MajicAttack = Instantiate(tmp);
        Vector3 cameraPosition = gameManagerScript.camera.transform.position;
        Vector3 cameraForward = gameManagerScript.camera.transform.forward;
        Vector3 spawnPosition = cameraPosition - cameraForward * 0.3f; // Adjust the multiplier to set the distance behind the camera
        MajicAttack.transform.position = new Vector3(spawnPosition.x, MajicAttack.transform.position.y, spawnPosition.z);
        Vector3 direction = gameManagerScript.camera.transform.position - this.gameObject.transform.position;
        direction.y = 0; // Keep only horizontal rotation
        MajicAttack.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        MajicAttack.transform.rotation *= Quaternion.Euler(0, 180, 0);
        Invoke(nameof(DelayMethod5), 1f);
    }

    void DelayMethod4(){
        animator.SetTrigger("Attack Trigger");
        gameManagerScript.SEprocess8 = true;
        Invoke(nameof(DelayMethod6), 1f);
    }

    void DelayMethod5(){
        gameManagerScript.process9 = true;
    }

    void DelayMethod6(){
        gameManagerScript.SEprocess9 = true;
    }
}
