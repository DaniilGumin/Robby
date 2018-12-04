using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera2 : MonoBehaviour {

	public Transform who;
	Vector3 position;

	void Start () {
		transform.position = who.position;
	}
 
	
	// Update is called once per frame
	void Update () {
		position = who.position;
		position.z = 0f;
		position.x = -7f;
		position.y = -3f;
		transform.position = Vector3.Lerp(transform.position, position, 0.8f*Time.deltaTime);
	}
}
