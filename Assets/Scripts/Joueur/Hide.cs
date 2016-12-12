using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour 
{
	public bool hide = false;
	public Sprite hidden;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Table") 
		{

		}
	}
}
