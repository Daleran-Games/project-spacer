using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshLayer : MonoBehaviour {

	public MeshLayerType MeshLayerOrder = MeshLayerType.WORLD_BASE;
	public int sizeX = 1;
	public int sizeY = 1;

	void Start () {
		
	}

	void BuildMesh () {
		
	}

}
