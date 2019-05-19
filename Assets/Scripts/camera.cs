using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour 
{
	public Transform who;
	Vector3 position;

	void Start () 
	{
		transform.position = who.position;
	}
 
	void Update () 
	{
		position = who.position;
		position.z = -7f;
		position.y = 0f;
		if(who.position.x>-10f && who.position.x<60f)
		{
		transform.position = Vector3.Lerp(transform.position, position,100.0f*Time.deltaTime);
		}
	}
}