<!-- ## フォントアセットの準備

1. **Window** -> **TextMeshPro** -> **Font Asset Creator**を押す
1. **Source Font File**に`Assets/Fonts/**/*.otf`を指定する
1. **Character Set**に**Characters from File**を指定する
1. **Character File**に`Assets/Fonts/jp-chars.txt`を指定する
1. **Generate Font Alias**を押す
1. `Assets/TextMesh Pro/Resources/Fonts & Materials`に保存する。 -->

sugiba0266666
nishio

## 外部アセットの追加

外部パッケージは再配布を避けるため、`Assets/Imported`以下に配置します。

<!-- - MediaPipeUnity
  - https://github.com/homuler/MediaPipeUnityPlugin
  - Releasesの`MediaPipeUnityPlugin-all.zip`をダウンロードする
  - [こちら](https://github.com/homuler/MediaPipeUnityPlugin/wiki/Getting-Started#build-and-import-a-unity-package)の手順に従ってパッケージをインポートする
  - macOSでの実行の際に **“libmediapipe_c.dylib”は、開発元を検証できないため開けません。** と表示される場合、`xattr -d com.apple.quarantine $(find **/libmediapipe_c.dylib)`の実行が必要です。 -->

## Microsoft.Azure.Kinectの準備

1. [Azure Kinect Body Tracking SDK](https://learn.microsoft.com/ja-jp/azure/kinect-dk/body-sdk-download)をインストールする
1. `C:\Program Files\Azure Kinect Body Tracking SDK\tools`にあるものを`/Assets/Imported/K4ABin`にコピーする
1. そのうちの`dnn_model_2_0_op11.onnx`を`/Assets/StreamingAssets`に移動する

## Emgu.TF.Liteの準備

1. [NuGet Galleryのページ](https://www.nuget.org/packages/Emgu.TF.Lite.runtime.windows)から直接`.nupkg`ファイルをダウンロードする
2. [7zip](https://7-zip.opensource.jp/)等で`.nupkg`ファイルを開き、その中の`/runtimes/win-x64/native/tfliteextern.dll`を`/Assets/Imported/EmguBin`にコピーする