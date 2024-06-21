using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Microsoft.Azure.Kinect.BodyTracking;
using Microsoft.Azure.Kinect.Sensor;
using System;

public class PoseDevice : IDisposable
{
    private Device _device;
    private DeviceConfiguration _deviceConfig;
    private Tracker _tracker;
    private PoseClassifier _classifier;

    private bool _isStarted = false;

    public bool IsStarted { get => _isStarted; private set => _isStarted = value; }
    public bool IsStopped { get => !_isStarted; private set => _isStarted = !value; }

    public Pose CurrentPose { get; private set; }

    public PoseDevice()
    {
        _device = Device.Open();
        _deviceConfig = new DeviceConfiguration
        {
            DepthMode = DepthMode.NFOV_Unbinned,
        };

        var calibration = _device.GetCalibration(_deviceConfig.DepthMode, _deviceConfig.ColorResolution);
        var trackerConfig = TrackerConfiguration.Default;
        trackerConfig.ModelPath = $"{Application.streamingAssetsPath}/dnn_model_2_0_op11.onnx";
        _tracker = Tracker.Create(calibration, trackerConfig);

        _classifier = new();
    }

    public void Dispose()
    {
        _tracker.Shutdown();
        _tracker.Dispose();
        _device.Dispose();

        _classifier.Dispose();
    }

    public void Start()
    {
        if (IsStarted)
        {
            return;
        }
        IsStarted = true;

        _device.StartCameras(_deviceConfig);
    }

    public void Stop()
    {
        if (IsStopped)
        {
            return;
        }
        IsStopped = true;

        _device.StopCameras();
    }

    public void Update()
    {
        using var capture = _device.GetCapture();
        _tracker.EnqueueCapture(capture);

        using var bodyFrame = _tracker.PopResult(TimeSpan.Zero, false);
        if (bodyFrame == null || bodyFrame.NumberOfBodies == 0)
        {
            return;
        }

        var bodySkelton = bodyFrame.GetBodySkeleton(0);
        var jointNormalizedVectors = K4AUtils.GetJointNormalizedVectors(bodySkelton);

        var pose = _classifier.Classify(jointNormalizedVectors);
        if (!pose.HasValue)
        {
            return;
        }

        CurrentPose = pose.Value;
    }
}
