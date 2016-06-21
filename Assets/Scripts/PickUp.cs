using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	public bool _holding;

	public GameObject _pick;


	
	// Update is called once per frame
	void OnTriggerStay (Collider other) {

		if (other.tag == "item") {
			_pick = other.gameObject;
		}

		if (Input.GetKeyDown (KeyCode.R)) {
		
			_holding = !_holding;
		
		}
	}

		void  Update () {

		if (_pick == null) {
			return;
		}

			if (_pick.GetComponent<ObjectClass> ()._pickable && _holding) {

				_pick.transform.parent = this.transform;
				_pick.GetComponent<MeshRenderer> ().enabled = false;

				if (Input.GetKey (KeyCode.E) && _pick.GetComponent<ObjectClass> ()._edible) {
				
					GetComponent<ObjectClass> ()._health += _pick.GetComponent<ObjectClass> ()._health;
					Destroy (_pick);
					_pick = null;
					

					}

			} else {

				_pick.transform.parent = null;
				_pick.GetComponent<MeshRenderer> ().enabled = true;
				_pick = null;

			}

	}
}