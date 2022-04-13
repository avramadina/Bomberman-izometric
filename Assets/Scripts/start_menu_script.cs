using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class start_menu_script : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
		
	}

	public void exit_pressed(){
		Application.Quit();
	}

	public void start_pressed(){

		 PlayerPrefs.SetInt("current_level", 0);
	
		     if (Application.CanStreamedLevelBeLoaded("Game"))
     {
		StartCoroutine(GameObject.FindObjectOfType<fade_script>().FadeAndLoadScene(fade_script.FadeDirection.In, "Game"));
	 } else {
		 	StartCoroutine(GameObject.FindObjectOfType<fade_script>().FadeAndLoadScene(fade_script.FadeDirection.In, "Game_mobile"));
	
	 }
	
	}
}
