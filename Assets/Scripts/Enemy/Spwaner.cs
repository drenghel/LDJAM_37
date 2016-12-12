using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwaner : MonoBehaviour 
{
	private int spawner = 0;
	private Vector3 position;
	private AudioSource Approach;

	public float time = 5;
	public GameObject[] target;
	public GameObject Zombie = null;


	void Start()
	{
		//Permet d'associer Approach avec AudioSource
		Approach = GetComponent<AudioSource> ();

		//Lance Le Timer
		StartCoroutine (Timer ());
	}


	//Début Timer
	IEnumerator Timer()
	{
		while (true) 
		{
			//Temps du timer ici 30s
			yield return new WaitForSeconds (time);

			//Lance le son
			Approach.Play ();
			//Spawn un Zombie
			Spawn ();
			//Temps aléatoir spawn
			time = Random.Range (30, 60);

			Debug.Log ("Time: " + time);
		}
	}

	void Spawn()
	{
		spawner = Random.Range (1, 10);

		switch (spawner)
		{
		case 1:
			position = target [0].transform.position;
			Instantiate (Zombie, position, Quaternion.identity);
			break;

		case 2:
			position = target [1].transform.position;
			Instantiate (Zombie, position, Quaternion.Euler(0, -90, 0));
			break;

		case 3:
			position = target [2].transform.position;
			Instantiate (Zombie, position, Quaternion.Euler(0, -90, 0));
			break;

		default:
			spawner = Random.Range (1, 3);
			break;
		}

		Debug.Log ("Spawner: " + spawner);
	}
}
