using UnityEngine;
using System.Collections;

public class WeaponMountModule : Part {

	Weapon[] weapons;
	//int weaponGroup;
	Controller controller;

	public override void Initialize () {
		partCollider = GetComponent<Collider2D> ();
		weapons = GetComponentsInChildren<Weapon> ();
		controller = transform.root.GetComponent<Controller> ();
		//weaponGroup = 1;
		modules = GetComponents<Module> ();
		InitializeModules ();

	}

	void Update () {
		if (controller.IsFiring ())
			OnFire (1);

	}

	public virtual void OnFire (int wpnGrp) {

		foreach (Weapon wpn in weapons) {
			wpn.Fire ();
		}
	
	}

	public virtual void Aim (Vector2 aimPoint) {
		
	}

	public virtual void SetWeaponGroup (int wpnGroup) {
		//weaponGroup = wpnGroup;
	}


}
