using UnityEngine;
using System.Collections;

public class Part : MonoBehaviour {

	public string partName;
	public float mass = 0.0f;

	protected Collider2D partCollider;
	public Module[] modules;


	public virtual void Initialize() {
		partCollider = GetComponent<Collider2D> ();
		modules = GetComponents<Module> ();
		InitializeModules ();
	}

	protected virtual void InitializeModules () {
		foreach (Module mod in modules) {
			mod.Initialize ();
		}
	}
		

}
