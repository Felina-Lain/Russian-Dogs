using UnityEngine;
using System.Collections;

public class Killzone : MonoBehaviour {

	void OnTriggerStay (Collider other)
	{
		GameObject thingie = other.transform.parent.gameObject;
		if (thingie.CompareTag ("Enemy")) 
		{
			Destroy (thingie);
		}
	}
}
