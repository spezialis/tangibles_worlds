using UnityEngine;

/* Add to this script the ZBuffer material to make the Maph Depht work */

[ExecuteInEditMode]
public class DephtMap : MonoBehaviour {

	public Material mat;

	void Start() {
		GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
	}

	void OnRenderImage(RenderTexture source, RenderTexture destination) {
		Graphics.Blit(source, destination, mat);
	}
}
