using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class birds : MonoBehaviour {
	public GameObject bird;


	void Update () {
		if(transform.position.x < 12f)
		{
			transform.position = new Vector3(transform.position.x+0.09f,transform.position.y,transform.position.z);
		}	 		
	}
	
}
