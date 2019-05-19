using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
	public class pause : MonoBehaviour 
	{
        public GameObject PauseButton;
		public GameObject NavigationMenu;
		public static bool Finished = false;
		

		void Update () 
		{
			if (Finished)
			{
				Finish();
			}
			else if (Varibales.Paused && !Varibales.Death)
			{
				StartPause();
			}
			else if (Varibales.Paused && Varibales.Death)
			{
				DeathPause();
			}
			else if(!Varibales.Paused)
			{
				Resume();
			}
			Time.timeScale = Varibales.time;
		}

		public void StartPause()
		{
			PauseButton.SetActive(false);
			NavigationMenu.SetActive(true);
			Varibales.Paused = true;
			Varibales.time = 0f;
			
		}
		public void DeathPause()
		{
			PauseButton.SetActive(false);
			Varibales.Paused = true;
			Varibales.time = 0f;
			
		}
		public void Resume()
		{
			PauseButton.SetActive(true);
			NavigationMenu.SetActive(false);
			Varibales.Paused = false;
			Varibales.time = 1f;
		}
		public void Finish()
		{
			PauseButton.SetActive(false);
			Varibales.Paused = true;
			Varibales.time = 0f;
		}
		public void StartMenu()
		{
			SceneManager.LoadScene("menu");
		}
	}
}