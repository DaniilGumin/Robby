using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenu : MonoBehaviour 
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
	public void Play(int sceneIndex)
	{
		StartCoroutine (LoadAsync(1));
	}

	public void Quit()
	{
		Application.Quit();
	}
}
