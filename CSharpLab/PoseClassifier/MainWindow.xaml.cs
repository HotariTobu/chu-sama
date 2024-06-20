using System.Buffers;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

using Microsoft.Azure.Kinect.Sensor;
using Microsoft.Azure.Kinect.BodyTracking;

namespace PoseClassifier;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private DataSource _dataSource;

    private Device _device;
    private DeviceConfiguration _deviceConfig;
    private Tracker _tracker;

    private DispatcherTimer _timer;

    private Classifier _classifier;

    public MainWindow()
    {
        InitializeComponent();

        if (DataContext is DataSource dataSource)
        {
            _dataSource = dataSource;
        }
        else
        {
            _dataSource = new();
        }

        _dataSource.CaptureImage = new(1920, 1080, 96, 96, PixelFormats.Bgra32, null);

        _device = Device.Open();
        _deviceConfig = new DeviceConfiguration
        {
            CameraFPS = FPS.FPS30,
            ColorFormat = ImageFormat.ColorBGRA32,
            ColorResolution = ColorResolution.R1080p,
            DepthMode = DepthMode.NFOV_Unbinned,
        };

        var calibration = _device.GetCalibration(_deviceConfig.DepthMode, _deviceConfig.ColorResolution);
        var tackerConfig = TrackerConfiguration.Default;
        _tracker = Tracker.Create(calibration, tackerConfig);

        _timer = new();
        _timer.Tick += new System.EventHandler(_timerTick);
        _timer.Interval = TimeSpan.FromMilliseconds(50);

        _classifier = new();
    }

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);

        _tracker.Shutdown();
        _tracker.Dispose();
        _device.Dispose();

        _classifier.Dispose();
    }

    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);
        _device.StartCameras(_deviceConfig);
        _timer.Start();
    }

    protected override void OnDeactivated(EventArgs e)
    {
        base.OnDeactivated(e);
        _device.StopCameras();
        _timer.Stop();
    }

    private unsafe void _timerTick(object? sender, EventArgs e)
    {
        using var capture = _device.GetCapture();
        _updateColorImage(capture);
        _updatePoseLabel(capture);
    }

    private unsafe void _updateColorImage(Capture capture)
    {
        using var image = capture.Color;
        if (image == null) {
            return;
        }

        var rect = new Int32Rect(0, 0, image.WidthPixels, image.HeightPixels);

        using var memoryHandle = image.Memory.Pin();
        var buffer = new IntPtr(memoryHandle.Pointer);

        _dataSource.CaptureImage?.WritePixels(rect, buffer, (int)image.Size, image.StrideBytes);
    }

    private void _updatePoseLabel(Capture capture)
    {
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

        _dataSource.PoseLabel = Enum.GetName(pose.Value);
    }
}
