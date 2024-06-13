// using System.Collections;
// using UnityEngine;
// using UnityEngine.UI;

// using Mediapipe;
// using Mediapipe.Unity;

// public class FaceMeshSample : MonoBehaviour
// {
//   [SerializeField] private RawImage Screen;
//   [SerializeField] private TextAsset GraphConfig;
//   [SerializeField] private int CameraWidth = 640;
//   [SerializeField] private int CameraHeight = 480;
//   [SerializeField] private int CameraFPS = 30;
//   [SerializeField] private int EmptyPacketThresholdMicrosecond = 50000;

//   private WebCamTexture? _webCamTexture;
//   private Texture2D? _inputTexture;
//   private Color32[]? _inputPixelData;
//   private Texture2D? _outputTexture;
//   private Color32[]? _outputPixelData;

//   private CalculatorGraph? _graph;
//   private OutputStream<ImageFrame>? _outputVideoStream;

//   private bool _isInitializing = true;

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
//     _outputTexture = new Texture2D(CameraWidth, CameraHeight, TextureFormat.RGBA32, false);
//     _outputPixelData = new Color32[CameraWidth * CameraHeight];

//     Screen.rectTransform.sizeDelta = new Vector2(CameraWidth, CameraHeight);
//     Screen.texture = _outputTexture;

//     var resourceManager = new StreamingAssetsResourceManager();
//     yield return resourceManager.PrepareAssetAsync("face_detection_short_range.bytes");
//     yield return resourceManager.PrepareAssetAsync("face_landmark_with_attention.bytes");

//     _graph = new CalculatorGraph(GraphConfig.text);

//     _outputVideoStream = new OutputStream<ImageFrame>(_graph, "output_video");
//     _outputVideoStream.AddListener(HandleOutputVideo, EmptyPacketThresholdMicrosecond);
//     _outputVideoStream.StartPolling();

//     _graph.StartRun();

//     _isInitializing = false;
//   }

//   private void Update()
//   {
//     if (_isInitializing)
//     {
//       return;
//     }

//     if (_webCamTexture == null || _inputTexture == null || _graph == null || _outputTexture == null)
//     {
//       return;
//     }

//     _webCamTexture.GetPixels32(_inputPixelData);
//     _inputTexture.SetPixels32(_inputPixelData);
//     var imageFrame = new ImageFrame(ImageFormat.Types.Format.Srgba, CameraWidth, CameraHeight, CameraWidth * 4, _inputTexture.GetRawTextureData<byte>());
//     var inputPacket = Packet.CreateImageFrameAt(imageFrame, (long)(Time.time * 1000));
//     _graph.AddPacketToInputStream("input_video", inputPacket);

//     _outputTexture.SetPixels32(_outputPixelData);
//     _outputTexture.Apply();
//   }

//   private void HandleOutputVideo(object _, OutputStream<ImageFrame>.OutputEventArgs args)
//   {
//     var outputVideoPacket = args.packet;
//     if (outputVideoPacket == null || _outputPixelData == null)
//     {
//       return;
//     }

//     var outputVideo = outputVideoPacket.Get();
//     outputVideo.TryReadPixelData(_outputPixelData);
//   }

//   private void OnDestroy()
//   {
//     _webCamTexture?.Stop();
//     _outputVideoStream?.Dispose();

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
// }
