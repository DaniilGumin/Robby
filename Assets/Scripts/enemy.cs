using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class enemy : MonoBehaviour {

	public GameObject Respawn;

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player"){
			Thread.Sleep(500);
			other.transform.position = Respawn.transform.position;
		}
	}
		
}

