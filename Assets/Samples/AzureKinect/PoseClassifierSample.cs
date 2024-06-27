using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Microsoft.Azure.Kinect.BodyTracking;
using Microsoft.Azure.Kinect.Sensor;
using System;

public class PoseClassifierSample : MonoBehaviour
{
    private PoseDevice _poseDevice;

    // Start is called before the first frame update
    void Start()
    {
        _poseDevice = new();
        _poseDevice.Start();
    }

    void OnDestroy()
    {
        _poseDevice.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        _poseDevice.Update();
        var pose = _poseDevice.CurrentPose;
        var poseName = Enum.GetName(typeof(Pose), pose);
        Debug.Log(poseName);
    }
}
