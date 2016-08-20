using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MeshSystem : GridSystem {

	GameObject parent;
	List<MeshLayer> layers;
	DataSystem gridData;

	void Start () {

		parent = this.gameObject;
		gridData = parent.GetComponent<DataSystem> ();

	}

	void BuildMeshLayerObjects () {


	}


}
