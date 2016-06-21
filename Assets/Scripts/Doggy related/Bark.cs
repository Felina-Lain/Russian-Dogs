using UnityEngine;
using System.Collections;

public class Bark : MonoBehaviour {

	public bool _bark;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.E) && !GetComponent<PickUp> ()._holding) {
		
			print ("WROUF! WROUF!");
			this.GetComponent<AudioSource> ().Play ();
			_bark = true;
		
		} else { 
			_bark = false;
		}
	
	}
}
