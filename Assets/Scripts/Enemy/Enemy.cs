using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	public float min = 0f;
	public float max = 10f;
	public AudioClip walk;

	private float speed = 0;

	void Start()
	{
		AudioSource.PlayClipAtPoint (walk, transform.position);
	}

	void Update () 
	{
		speed = Random.Range (min, max);

		Move ();
	}

	void Move()
	{
		transform.Translate (Vector3.left * speed * Time.deltaTime);
	}
}
