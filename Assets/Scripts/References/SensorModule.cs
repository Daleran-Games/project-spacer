using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SensorModule : Module {

	public CircleCollider2D sensor;
	public List<zGrid> contacts;


	public override  void Initialize () {
		sensor = gameObject.GetComponent<CircleCollider2D> ();
		contacts = new List<zGrid> ();
	}

	public List<zGrid> GetContacts() {
		return contacts;
	}

	public virtual void OnTriggerEnter2D (Collider2D contact) {
		contacts.Add (contact.GetComponentInParent<zGrid>());
	}

	public void OnTriggerExit2D (Collider2D contact) {
		contacts.Remove (contact.GetComponentInParent<zGrid>());
	}
}
