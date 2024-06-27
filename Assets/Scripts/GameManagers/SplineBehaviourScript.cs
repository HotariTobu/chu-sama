using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    private SplineAnimate splineContainer;
    void Start()
    {
        var splineContainer = GetComponent<SplineAnimate>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){splineContainer.enabled = false;}
    }
}
