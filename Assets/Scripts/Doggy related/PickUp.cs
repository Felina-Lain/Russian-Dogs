using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	public bool _holding;
	public bool _baballe;
	public GameObject _pick;


	
	// Update is called once per frame
	void OnTriggerStay (Collider other) {

		if (other.tag == "item" && !_holding) {
			_pick = other.gameObject;
		}

		if (other.tag == "Enemy" && _baballe) 
		{
			Debug.Log ("I WILL TAKE YOUR FOOD");
			_pick.GetComponent<ObjectClass> ()._carried = false;
			//_pick.transform.parent = null;
			_pick.GetComponent<MeshRenderer> ().enabled = true;
			_pick = null;
			_baballe = false;
		}


	}

		void  Update () {

		Manager.player_iscarrying = _baballe;
		

		if (Input.GetKeyDown (KeyCode.R)) {

			_holding = !_holding;


		}

		if (_pick == null) {
			return;
		}

			if (_pick.GetComponent<ObjectClass> ()._pickable && _holding) {

				//_pick.transform.parent = this.transform;
				_pick.GetComponent<MeshRenderer> ().enabled = false;
				_baballe = true;
			_pick.GetComponent<ObjectClass> ()._carried = true;

			if (_pick.GetComponent<ObjectClass> ()._carried == true) {

				_pick.transform.position = GameObject.FindWithTag ("Player").transform.position;

			/*	if (Manager.player_direction == "Left") {

					Vector3 newPos = (GameObject.FindWithTag ("CarryPointLeft").transform.localPosition) + (GameObject.FindWithTag ("Player").transform.localPosition);
					
					_pick.transform.position = newPos ;
				} 

				if (Manager.player_direction == "Right")
					
				{
					Vector3 newPos = (GameObject.FindWithTag ("CarryPointRight").transform.localPosition) + (GameObject.FindWithTag ("Player").transform.localPosition);
					_pick.transform.position = newPos;
				} */

			}



			//eating stuff
				if (Input.GetKey (KeyCode.E) && _pick.GetComponent<ObjectClass> ()._edible) {
				
					GetComponent<ObjectClass> ()._health += _pick.GetComponent<ObjectClass> ()._health;
					AudioClip eat = Resources.Load ("eat") as AudioClip;
					AudioSource audioeat = this.GetComponent<AudioSource> ();
					audioeat.clip = eat;
					audioeat.Play ();
					Destroy (_pick);
					_pick = null;
					_holding = false;
					_baballe = false;

					}

		} else if(!_holding){
			_pick.GetComponent<ObjectClass> ()._carried = false;
				//_pick.transform.parent = null;
				_pick.GetComponent<MeshRenderer> ().enabled = true;
				_pick = null;
				_baballe = false;

			}

	}
}