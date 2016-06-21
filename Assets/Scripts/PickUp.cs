using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	public bool _holding;


	
	// Update is called once per frame
	void OnTriggerStay (Collider other) {

		if (Input.GetKeyDown (KeyCode.R)) {
		
			_holding =! _holding;
		
		}
		GameObject _pick = other.gameObject;

		if (_pick.GetComponent<ObjectClass> ()._pickable && _holding) {
		
			_pick.transform.parent = this.transform;
		
		} else {

			_pick.transform.parent = null;
			_pick = null;
		
		}
	
	}
		
}
