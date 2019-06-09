using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour 
{

	public GameObject PortalOut;
	private AudioSource Audio;
	
	public void Start()
	{
		Audio = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		Audio.Play();
		other.transform.position = PortalOut.transform.position;
	}	
}
