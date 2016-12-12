using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	public float min = 0f;
	public float max = 10f;

	private float speed = 0;
	private AudioSource walk;

	void Start()
	{
		walk = GetComponent<AudioSource> ();
		walk.Play ();
	}

	void Update () 
	{
		speed = Random.Range (min, max);

		Move ();
	}

	void Move()
	{
		transform.position += Vector3.left * speed * Time.deltaTime;
	}
}
