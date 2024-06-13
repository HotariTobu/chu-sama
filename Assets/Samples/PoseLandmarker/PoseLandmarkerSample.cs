// using System.Collections;
// using UnityEngine;

// using Mediapipe;
// using Mediapipe.Unity;

// public class PoseLandmarkerSample : MonoBehaviour
// {
//   [SerializeField] private TextAsset GraphConfig;
//   [SerializeField] private int CameraWidth = 640;
//   [SerializeField] private int CameraHeight = 480;
//   [SerializeField] private int CameraFPS = 30;
//   [SerializeField] private int EmptyPacketThresholdMicrosecond = 50000;

//   private WebCamTexture? _webCamTexture;
//   private Texture2D? _inputTexture;
//   private Color32[]? _inputPixelData;

//   private CalculatorGraph? _graph;
//   private OutputStream<NormalizedLandmarkList>? _outputLandmarksStream;

//   private bool _isInitializing = true;
//   private long _timestamp = 0;

//   private void Awake()
//   {
//     Protobuf.SetLogHandler(Protobuf.DefaultLogHandler);
//   }

//   private IEnumerator Start()
//   {
//     if (WebCamTexture.devices.Length == 0)
//     {
//       throw new System.Exception("Web Camera devices are not found");
//     }

//     var webCamDevice = WebCamTexture.devices[0];
//     _webCamTexture = new WebCamTexture(webCamDevice.name, CameraWidth, CameraHeight, CameraFPS);
//     _webCamTexture.Play();

//     _inputTexture = new Texture2D(CameraWidth, CameraHeight, TextureFormat.RGBA32, false);
//     _inputPixelData = new Color32[CameraWidth * CameraHeight];

//     var resourceManager = new StreamingAssetsResourceManager();
//     yield return resourceManager.PrepareAssetAsync("pose_detection.bytes");
//     yield return resourceManager.PrepareAssetAsync("pose_landmark_full.bytes");

//     _graph = new CalculatorGraph(GraphConfig.text);

//     _outputLandmarksStream = new OutputStream<NormalizedLandmarkList>(_graph, "pose_landmarks");
//     _outputLandmarksStream.AddListener(HandleOutputVideo, EmptyPacketThresholdMicrosecond);
//     _outputLandmarksStream.StartPolling();

//     var sidePacket = new PacketMap();

//     sidePacket.Emplace("input_rotation", Packet.CreateInt((int)RotationAngle.Rotation0));
//     sidePacket.Emplace("input_horizontally_flipped", Packet.CreateBool(false));
//     sidePacket.Emplace("input_vertically_flipped", Packet.CreateBool(false));

//     sidePacket.Emplace("output_rotation", Packet.CreateInt((int)RotationAngle.Rotation0));
//     sidePacket.Emplace("output_horizontally_flipped", Packet.CreateBool(false));
//     sidePacket.Emplace("output_vertically_flipped", Packet.CreateBool(false));

//     sidePacket.Emplace("model_complexity", Packet.CreateInt((int)ModelComplexity.Full));
//     sidePacket.Emplace("smooth_landmarks", Packet.CreateBool(false));
//     sidePacket.Emplace("enable_segmentation", Packet.CreateBool(false));
//     sidePacket.Emplace("smooth_segmentation", Packet.CreateBool(false));

//     _graph.StartRun(sidePacket);

//     _isInitializing = false;
//   }

//   private void Update()
//   {
//     if (_isInitializing)
//     {
//       return;
//     }

//     if (_webCamTexture == null || _inputTexture == null || _graph == null)
//     {
//       return;
//     }

//     _webCamTexture.GetPixels32(_inputPixelData);
//     _inputTexture.SetPixels32(_inputPixelData);
//     var imageFrame = new ImageFrame(ImageFormat.Types.Format.Srgba, CameraWidth, CameraHeight, CameraWidth * 4, _inputTexture.GetRawTextureData<byte>());
//     var inputPacket = Packet.CreateImageFrameAt(imageFrame, _timestamp++);
//     _graph.AddPacketToInputStream("input_video", inputPacket);
//   }

//   private void HandleOutputVideo(object _, OutputStream<NormalizedLandmarkList>.OutputEventArgs args)
//   {
//     var outputLandmarkPacket = args.packet;
//     if (outputLandmarkPacket == null)
//     {
//       return;
//     }

//     var outputLandmarkList = outputLandmarkPacket.Get(NormalizedLandmarkList.Parser);
//     var i = 0;
//     foreach (var outputLandmark in outputLandmarkList.Landmark)
//     {
//       Debug.Log($"{i}: ({outputLandmark.X}, {outputLandmark.Y}, {outputLandmark.Z})");
//       i++;
//     }
//   }

//   private void OnDestroy()
//   {
//     _webCamTexture?.Stop();
//     _outputLandmarksStream?.Dispose();

//     if (_graph != null)
//     {
//       try
//       {
//         _graph.CloseInputStream("input_video");
//         _graph.WaitUntilDone();
//       }
//       finally
//       {
//         _graph.Dispose();
//       }
//     }

//     Protobuf.ResetLogHandler();
//   }

//   private enum ModelComplexity
//   {
//     Lite = 0,
//     Full = 1,
//     Heavy = 2,
//   }
// }
