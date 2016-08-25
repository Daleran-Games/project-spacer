using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "NewTileFX", menuName = "Data/Graphics/Tile FX", order = 2)]
public class TileFX : ScriptableObject {

	public MeshLayerType Layer;
	public TileState State;
	public TileShape Shape;
	public TileSprite[] Sprites;
	public ParticleSystem ParticleFX;
	public AudioSource TileSound;



}
