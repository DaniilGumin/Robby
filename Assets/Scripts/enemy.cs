using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

namespace Scripts
{
	public class enemy : MonoBehaviour 
	{
		public GameObject DeathMenu;
		

		void OnTriggerEnter2D (Collider2D other)
		{
			if (other.tag == "Player")
			{
				Thread.Sleep(500);
				Varibales.Death = true;
			}
		}		
	}
}