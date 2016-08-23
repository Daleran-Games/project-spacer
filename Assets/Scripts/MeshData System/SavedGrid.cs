using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewGrid", menuName = "Data/Grid", order = 0)]
public class SavedGrid : ScriptableObject {

    public Info GridInfo;
	public List<SavedGridLine> TileRows;




}
