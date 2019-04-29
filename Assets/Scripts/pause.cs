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
		public bool Paused = false;
		public static bool Finished = false;
		

		void Update () 
		{
			if (Finished)
			{
				Finish();
			}
			else if (Paused)
			{
				StartPause();
			}
			else if(!Paused)
			{
				StartResume();
			}
			
		}

		public void StartPause()
		{
			PauseButton.SetActive(false);
			NavigationMenu.SetActive(true);
			Paused = true;
			Time.timeScale = 0f;
		}
		public void StartResume()
		{
			PauseButton.SetActive(true);
			NavigationMenu.SetActive(false);
			Paused = false;
			Time.timeScale = 1f;
		}
		public void Finish()
		{
			PauseButton.SetActive(false);
			Paused = true;
			Time.timeScale = 0f;
		}
		public void StartMenu()
		{
			SceneManager.LoadScene("menu");
		}
	}
}