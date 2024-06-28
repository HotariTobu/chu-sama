using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuscleBehaviourScript : MonoBehaviour
{
    Animator animator;
    int cnt;
    private GameObject gameManager;
    private GameManagerScript gameManagerScript;
    private HealthBehaviourScript healthBehaviourScript;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();
        healthBehaviourScript = gameManager.GetComponent<HealthBehaviourScript>();
        animator = GetComponent<Animator>();
        cnt = 0;
        Invoke(nameof(DelayMethod1), 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagerScript.Attackjudge == false){
            Vector3 newPosition = this.transform.position;
            newPosition.x = gameManagerScript.target.transform.position.x;
            newPosition.z = gameManagerScript.target.transform.position.z;
            this.transform.position = newPosition;

            Vector3 directionToFace = gameManagerScript.camera.transform.position - transform.position;
            directionToFace.y = 0; // Keep only horizontal rotation
            transform.rotation = Quaternion.LookRotation(directionToFace);
        }

        if(gameManagerScript.process8 == true && gameManagerScript.isCollect == false){
            gameManagerScript.process8 = false;
            Invoke(nameof(DelayMethod4), 1.5f);
        }

        if(gameManagerScript.process8 == true && gameManagerScript.isCollect == true){
            gameManagerScript.process8 = false;
            Invoke(nameof(DelayMethod3), 1.2f);
            cnt++;
        }

        if(gameManagerScript.DestSign == true){
            gameManagerScript.DestSign = false;
            Invoke(nameof(DelayMethod2), 0.3f);
        }
    }

    void DelayMethod1(){
        GameObject tmp_Perticle1 = Resources.Load<GameObject>("Characters/EarthCrack");
        GameObject Perticle1 = Instantiate(tmp_Perticle1);
        GameObject Input1 = GameObject.Find("EarthCrack(Clone)");

        Vector3 newPosition = Input1.transform.position;
        newPosition.x = gameManagerScript.target.transform.position.x;
        newPosition.z = gameManagerScript.target.transform.position.z;
        Input1.transform.position = newPosition;

        Vector3 directionToFace = gameManagerScript.camera.transform.position - Input1.transform.position;
        directionToFace.y = 0; // Keep only horizontal rotation
        Input1.transform.rotation = Quaternion.LookRotation(directionToFace);
        Input1.transform.rotation *= Quaternion.Euler(-90, 0, 0);

    }

    void DelayMethod2(){
        Destroy(this.gameObject);
    }

    void DelayMethod3(){
        animator.SetTrigger("Damaged Trigger");
        gameManagerScript.SEprocess6 = true;
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
        Invoke(nameof(DelayMethod6), 0.45f);
    }

    void DelayMethod5(){
        gameManagerScript.process9 = true;
    }

    void DelayMethod6(){
        gameManagerScript.SEprocess13 = true;
        GameObject tmp_Perticle1 = Resources.Load<GameObject>("Characters/ScreenCrack");
        GameObject Perticle1 = Instantiate(tmp_Perticle1);
        GameObject Input1 = GameObject.Find("ScreenCrack(Clone)");

        Vector3 newPosition = Input1.transform.position;
        newPosition.x = gameManagerScript.target5.transform.position.x;
        // newPosition.y = gameManagerScript.target5.transform.position.y;
        newPosition.z = gameManagerScript.target5.transform.position.z;
        Input1.transform.position = newPosition;

        Vector3 directionToFace = gameManagerScript.camera.transform.position - Input1.transform.position;
        directionToFace.y = 0; // Keep only horizontal rotation
        Input1.transform.rotation = Quaternion.LookRotation(directionToFace);
        Input1.transform.rotation *= Quaternion.Euler(0, 0, 0);
    }
}
