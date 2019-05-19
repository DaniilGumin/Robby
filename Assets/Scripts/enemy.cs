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
				StartPause();
			}
		}		
		public void StartPause()
		{
			DeathMenu.SetActive(true);
			Varibales.time = 0f;
			Varibales.Paused = true;
			Varibales.Death = true;
		}
	}
}