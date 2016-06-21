using UnityEngine;
using System.Collections;

public class Bark : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.E) && !GetComponent<PickUp> ()._holding) {
		
			print ("WROUF! WROUF!");
		
		}
	
	}
}
