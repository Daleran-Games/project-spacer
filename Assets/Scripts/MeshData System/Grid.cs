using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class Grid : MonoBehaviour {

	Rigidbody2D GridRigidbody;
	List<GridSystem> GridSystems;

	public SavedGrid Saved;

	// Use this for initialization
	void Start () {

		GridSystems = new List<GridSystem> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitializeGrid (SavedGrid savedGrid) {

		Saved = savedGrid;

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
		GridSystems.Add (this.GetComponent<DataSystem> ());
		gameObject.AddComponent<MeshSystem> ();
		GridSystems.Add (this.GetComponent<MeshSystem> ());
			
	}
		


}
