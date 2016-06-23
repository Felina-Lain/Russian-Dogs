using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour 
{
	public string Scene;
	void Update()
	{

	}
	void OnTriggerEnter (Collider other)
	{

		if (other.CompareTag ("Player")) 
		{
			Debug.Log ("Player here");
			SceneManager.LoadScene(Scene);
		}
	}

}
