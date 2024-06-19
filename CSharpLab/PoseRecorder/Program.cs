using Microsoft.Azure.Kinect.Sensor;
using Microsoft.Azure.Kinect.BodyTracking;

const int MAX_FRAME_COUNT = 2000;

using var device = Device.Open();
var deviceConfig = new DeviceConfiguration()
{
    // CameraFPS = FPS.FPS30,
    DepthMode = DepthMode.NFOV_Unbinned,
    // ColorResolution = ColorResolution.Off
};

device.StartCameras(deviceConfig);

var calibration = device.GetCalibration(deviceConfig.DepthMode, deviceConfig.ColorResolution);

var tackerConfig = TrackerConfiguration.Default;
using var tracker = Tracker.Create(calibration, tackerConfig);

var path = $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.dat";
using var stream = File.OpenWrite(path);
using var writer = new StreamWriter(stream);

await Task.Delay(2000);
Console.WriteLine(string.Join(' ', Enumerable.Repeat("START!", 100)));

var frameCount = 0;

while (frameCount < MAX_FRAME_COUNT)
{
    using (var capture = device.GetCapture())
    {
        tracker.EnqueueCapture(capture);
    }

    await Task.Delay(50);

    using var bodyFrame = tracker.PopResult();
    if (bodyFrame.NumberOfBodies == 0)
    {
        continue;
    }

    var bodySkelton = bodyFrame.GetBodySkeleton(0);
    var jointNormalizedVectors = K4AUtils.GetJointNormalizedVectors(bodySkelton);

    var lineTokens = jointNormalizedVectors.Select(v => $"{v.X},{v.Y},{v.Z}");
    var line = string.Join(" ", lineTokens);
    writer.WriteLine(line);

    frameCount++;
}

tracker.Shutdown();
device.StopCameras();

Console.WriteLine($"Written in: {Path.GetFullPath(path)}");