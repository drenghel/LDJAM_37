using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("HELLO");

		if (other.gameObject.tag == "Zombie") {
			Destroy (other.gameObject);
		}
	}
}
