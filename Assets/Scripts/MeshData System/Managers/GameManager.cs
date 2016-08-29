using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Material TextureAtlas;

    public static GameManager manager;
    public static GameDatabase database;
   
    // Use this for initialization
    void Awake () {

        GV.atlas = TextureAtlas;

    }
	
}
