using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class ReverseNormals : MonoBehaviour {

	void Start () {
		MeshFilter filter = GetComponent (typeof(MeshFilter)) as MeshFilter;
		if (filter != null) {
			Mesh mesh = filter.mesh;

			Vector3[] normals = mesh.normals;
			for (int i = 0; i < normals.Length; i++) {
				normals [i] = -normals [i];
				mesh.normals = normals;

				for (int m = 0; m < mesh.subMeshCount; m++) {
					int[] triangles = mesh.GetTriangles (m);

					for (int j = 0; j < triangles.Length; j+=3) {
						int temp = triangles [j + 0];
						triangles [j + 0] = triangles [j + 1];
						triangles [j + 1] = temp;
					}
					mesh.SetTriangles (triangles, m);
				}

			}
		}
	}
}
