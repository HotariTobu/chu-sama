using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Microsoft.Azure.Kinect.BodyTracking;
using Microsoft.Azure.Kinect.Sensor;
using System;

public class StartPoseBehaviourScript : MonoBehaviour
{
    private PoseDevice _poseDevice;
    private TitleBehaviourScript TitleBehaviourScript;

    // Start is called before the first frame update
    void Start()
    {
        TitleBehaviourScript = GetComponent<TitleBehaviourScript>();
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
        if (_lastPose == pose)
        {
            TitleBehaviourScript.poses = 0;
        } else {
            switch(pose) {
                case Pose.NONE:
                    TitleBehaviourScript.poses = 0;
                    break;
                case Pose.RIGHT:
                    TitleBehaviourScript.poses = 1;
                    break;
                case Pose.LEFT:
                    TitleBehaviourScript.poses = 2;
                    break;
                case Pose.OK:
                    TitleBehaviourScript.poses = 3;
                    break;
                case Pose.BAD:
                    TitleBehaviourScript.poses = 4;
                    break;
                case Pose.Y:
                    TitleBehaviourScript.poses = 5;
                    break;
                case Pose.M:
                    TitleBehaviourScript.poses = 6;
                    break;
                case Pose.C:
                    TitleBehaviourScript.poses = 7;
                    break;
                case Pose.A:
                    TitleBehaviourScript.poses = 8;
                    break;
            }
        }
    }
}
