using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScentInfo : MonoBehaviour {

	public GameObject _icon;


	void OnTriggerStay (Collider other) {

		if (other.tag == "Player") {
			
			for (int i = 0; i < Manager.s_scentL.Count; i++) {


				if (Manager.s_scentL [i] == this.name) {
					_icon.GetComponent<Image> ().enabled = true;
					_icon.GetComponent<Image> ().overrideSprite = Manager.s_iconsL[i] as Sprite;
				}

			}
					
		}
	
	}

	void OnTriggerExit (Collider other){
	
		if (other.tag == "Player") {
		
//			_icon.GetComponent<Image> ().enabled = false;
		
		}
	
	}
}
