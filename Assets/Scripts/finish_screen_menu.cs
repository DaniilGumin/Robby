using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace Scripts
{
	public class finish_screen_menu : MonoBehaviour 
	{
		public GameObject Menu;
		public GameObject loadingScreen;
		public Slider slider;
		public Text text;


		IEnumerator LoadAsync(int sceneIndex)
		{
			AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
			loadingScreen.SetActive (true);

			while (!operation.isDone)
			{
				float progress = Mathf.Clamp01(operation.progress / 0.9f);
				slider.value = progress;
				text.text = (int) progress*100f+"%";

				yield return null;
			}
		}

		public void Start()
		{
			Menu.SetActive(true);
		}	

		public void LoadLvl()
		{
			StartCoroutine (LoadAsync(SceneManager.GetActiveScene().buildIndex+1));
		}

		public void Main_menu()
		{
			SceneManager.LoadScene("SkillsTree");
		}

		public void Retry( )
		{
			StartCoroutine (LoadAsync(SceneManager.GetActiveScene().buildIndex));
			Varibales.time = 1f;
			Varibales.Paused = false;
			Varibales.Death = false;
		}
	}
}