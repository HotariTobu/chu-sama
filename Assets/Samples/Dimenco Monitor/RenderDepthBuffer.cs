using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderDepthBuffer : MonoBehaviour
{
	private RenderTexture m_colorTex;
	private RenderTexture m_depthTex;
	public Material m_postRenderMat;

	void Start ()
	{
		Camera cam = GetComponent<Camera>();
		cam.depthTextureMode = DepthTextureMode.Depth;

		// カラーバッファ用 RenderTexture
		m_colorTex = new RenderTexture(Screen.width, Screen.height, 0, RenderTextureFormat.ARGB32);
		m_colorTex.Create();

		// デプスバッファ用 RenderTexture
		m_depthTex = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.Depth);
		m_depthTex.Create();

		// cameraにカラーバッファとデプスバッファをセットする
		cam.SetTargetBuffers(m_colorTex.colorBuffer, m_depthTex.depthBuffer);
	}

	void OnPostRender()
	{
		// RenderTarget無し：画面に出力される
		Graphics.SetRenderTarget(null);

		// デプスバッファを描画する(m_postRenderMatはテクスチャ画像をそのまま描画するマテリアル)
		Graphics.Blit(m_depthTex, m_postRenderMat);
	}
}
