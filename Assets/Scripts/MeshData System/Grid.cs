using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class Grid : MonoBehaviour {

	Rigidbody2D GridRigidbody;
	List<IGridSystem> GridSystems;

	public SavedGrid Saved;
    public Info GridInfo;

	// Use this for initialization
	void Start () {

		GridSystems = new List<IGridSystem> ();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitializeGrid (SavedGrid savedGrid) {

		Saved = savedGrid;

        GridInfo = Saved.GridInfo;

		if (this.GetComponent<Rigidbody2D> () != null)
			GridRigidbody = this.GetComponent<Rigidbody2D> ();
		else {
			gameObject.AddComponent<Rigidbody2D> ();
			GridRigidbody = this.GetComponent<Rigidbody2D> ();
			GridRigidbody.gravityScale = 0f;
			GridRigidbody.angularDrag = 0f;
			GridRigidbody.drag = 0f;

		}

		gameObject.AddComponent<DataSystem> ();
        gameObject.GetRequiredComponent<DataSystem>().BuildDataLayers(Saved);
        //GridSystems.Add (this.GetComponent<DataSystem> () as IGridSystem);

		gameObject.AddComponent<MeshSystem> ();
        gameObject.GetRequiredComponent<MeshSystem>().BuildMeshLayerObjects();
		//GridSystems.Add (this.GetComponent<MeshSystem> ());
			
	}
		


}
