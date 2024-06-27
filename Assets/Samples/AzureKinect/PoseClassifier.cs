using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using Emgu.TF.Lite;

public class PoseClassifier : System.IDisposable
{
    private static string s_modelFileName = "pose.tflite";

    private FlatBufferModel _model;
    private Interpreter _interpreter;

    private Tensor _inputTensor;
    private Tensor _outputTensor;

    public PoseClassifier()
    {
        var modelPath = $"{UnityEngine.Application.streamingAssetsPath}/{s_modelFileName}";
        if (!File.Exists(modelPath))
        {
            throw new FileNotFoundException($"A pose model file of TFlite must be located in the working dir and the filename must be `{modelPath}`.");
        }

        _model = new FlatBufferModel(modelPath);
        _interpreter = new Interpreter(_model);
        _interpreter.AllocateTensors();

        var inputIndex = _interpreter.InputIndices[0];
        var outputIndex = _interpreter.OutputIndices[0];

        _inputTensor = _interpreter.GetTensor(inputIndex);
        _outputTensor = _interpreter.GetTensor(outputIndex);
    }

    public void Dispose()
    {
        _model.Dispose();
        _interpreter.Dispose();

        _inputTensor.Dispose();
        _outputTensor.Dispose();
    }

    public Pose? Classify(IEnumerable<Vector3> jointNormalizedVectors)
    {
        var inputData = jointNormalizedVectors.SelectMany(
            vector => new float[] { vector.X, vector.Y, vector.Z }
            ).ToArray();

        Marshal.Copy(inputData, 0, _inputTensor.DataPointer, inputData.Length);

        var status = _interpreter.Invoke();
        if (status != Status.Ok)
        {
            return null;
        }

        var outputData = new float[_outputTensor.ByteSize / sizeof(float)];

        Marshal.Copy(_outputTensor.DataPointer, outputData, 0, outputData.Length);

        var maxIndex = 0;
        for (var i = 1; i < outputData.Length; i++)
        {
            if (outputData[maxIndex] < outputData[i])
            {
                maxIndex = i;
            }
        }

        return (Pose)maxIndex;
    }
}