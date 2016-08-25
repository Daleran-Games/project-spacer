using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MeshSystem : MonoBehaviour, IGridSystem {

	public GameObject parent;
	public List<MeshLayer> layers;
	public DataSystem gridData;


	public void BuildMeshLayerObjects () {

        parent = this.gameObject;
        gridData = parent.GetComponent<DataSystem>();
        layers = new List<MeshLayer>();

        List<MeshLayerType> meshLayerTypes = gridData.GetMeshLayerTypes();

        foreach (MeshLayerType ml in meshLayerTypes)
        {

            GameObject newLayer = Instantiate(parent.GetRequiredComponent<_Test>().meshLayer, this.transform) as GameObject;
            newLayer.transform.position = new Vector3(-gridData.GridSizeX*0.5f, -gridData.GridSizeY * 0.5f, 0f);
            MeshLayer newMeshLayer = newLayer.GetRequiredComponent<MeshLayer>();
            layers.Add(newMeshLayer);
            newMeshLayer.MeshLayerOrder = ml;
            newLayer.name = newMeshLayer.MeshLayerOrder.ToString();
            newMeshLayer.sizeX = gridData.GridSizeX;
            newMeshLayer.sizeY = gridData.GridSizeY;
            newMeshLayer.BuildMesh();
            newMeshLayer.buildTexture(gridData);

        }

	}


}
