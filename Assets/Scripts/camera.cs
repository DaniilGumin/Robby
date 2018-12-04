using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
	
	public Transform who;
	Vector3 position;

	void Start () {
		transform.position = who.position;
	}
 
	
	// Update is called once per frame
	void Update () {
		position = who.position;
		position.z = -5f;
		position.x = 0f;
		transform.position = Vector3.Lerp(transform.position, position,2.0f*Time.deltaTime);
	}
}