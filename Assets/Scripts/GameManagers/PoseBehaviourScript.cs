using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Microsoft.Azure.Kinect.BodyTracking;
using Microsoft.Azure.Kinect.Sensor;
using System;

public class PoseBehaviourScript : MonoBehaviour
{
    private PoseDevice _poseDevice;
    private GameManagerScript gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GetComponent<GameManagerScript>();
        _poseDevice = new();
        _poseDevice.Start();
    }

    void OnDestroy()
    {
        _poseDevice.Dispose();
    }

    private Pose _lastPose;

    // Update is called once per frame
    void Update()
    {
        _poseDevice.Update();
        var pose = _poseDevice.CurrentPose;
        if (_lastPose != pose){
            switch(pose) {
                case Pose.NONE:
                    gameManagerScript.poses = 0;
                    break;
                case Pose.RIGHT:
                    gameManagerScript.poses = 1;
                    break;
                case Pose.LEFT:
                    gameManagerScript.poses = 2;
                    break;
                case Pose.OK:
                    gameManagerScript.poses = 3;
                    break;
                case Pose.BAD:
                    gameManagerScript.poses = 4;
                    break;
                case Pose.Y:
                    gameManagerScript.poses = 5;
                    break;
                case Pose.M:
                    gameManagerScript.poses = 6;
                    break;
                case Pose.C:
                    gameManagerScript.poses = 7;
                    break;
                case Pose.A:
                    gameManagerScript.poses = 8;
                    break;
            }
        }
    }
}

