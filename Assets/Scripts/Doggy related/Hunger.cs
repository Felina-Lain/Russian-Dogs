using UnityEngine;
using System.Collections;

public class Hunger : MonoBehaviour {

	public float _start_chrono;
	public float _chrono;

	// Use this for initialization
	void Start () {

		_chrono = _start_chrono;
	
	}
	
	// Update is called once per frame
	void Update () {

		_chrono -= Time.deltaTime;

		if (_chrono <= 0) {
			GetComponent<ObjectClass> ()._health -= 1;
			_chrono = _start_chrono;
		}

		if (GetComponent<ObjectClass> ()._health == 0) {
		
			Destroy (this.gameObject);
		
		}
	
	}
}
