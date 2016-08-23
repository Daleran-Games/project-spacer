using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class _Test : MonoBehaviour {

    public SavedGrid SavedTestGrid;
    public GameObject meshLayer;
    Grid TestGrid;


	void Start () {
        this.gameObject.name = SavedTestGrid.GridInfo.name;
        this.gameObject.AddComponent<Grid>();
        TestGrid = this.gameObject.GetRequiredComponent<Grid>();
        TestGrid.InitializeGrid(SavedTestGrid);


	}


}
