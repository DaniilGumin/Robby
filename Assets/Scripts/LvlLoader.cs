﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LvlLoader : MonoBehaviour 
{
	public GameObject loadingScreen;
	public Slider slider;
	public Text text;

	public void LoadLvl(int sceneIndex)
	{
		StartCoroutine (LoadAsync(sceneIndex));
	}

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
}
