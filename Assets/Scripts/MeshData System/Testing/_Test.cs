using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class _Test : MonoBehaviour {

    public SavedGrid SavedTestGrid;

    public Controller GridController;
    Grid TestGrid;


	void Start () {

        gameObject.name = SavedTestGrid.GridInfo.name;
        gameObject.AddComponent<Grid>();
        TestGrid = gameObject.GetRequiredComponent<Grid>();
        TestGrid.InitializeGrid(SavedTestGrid, GridController);


	}


}
