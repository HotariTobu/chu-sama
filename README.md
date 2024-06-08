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

- MediaPipeUnity
  - https://github.com/homuler/MediaPipeUnityPlugin
  - Releasesの`MediaPipeUnityPlugin-all.zip`をダウンロードする
  - [こちら](https://github.com/homuler/MediaPipeUnityPlugin/wiki/Getting-Started#build-and-import-a-unity-package)の手順に従ってパッケージをインポートする
  - macOSでの実行の際に **“libmediapipe_c.dylib”は、開発元を検証できないため開けません。** と表示される場合、`xattr -d com.apple.quarantine $(find **/libmediapipe_c.dylib)`の実行が必要です。
