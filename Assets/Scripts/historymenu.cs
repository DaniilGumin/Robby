using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class historymenu : MonoBehaviour {
	public GameObject Menu;

	public void Start(){
		Menu.SetActive(true);
	}	
	
	public void Back(){
		SceneManager.LoadScene("menu");

	}
}
