﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal_script : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		
	}

	

	  void OnCollisionEnter(Collision collision)
    
    {
	
        if (collision.collider.CompareTag ("Player"))
        {
			
			Player p = collision.collider.GetComponent<Player>();
			
			 if(p.GetComponent<Player_Controller>().isActiveAndEnabled && !p.dead){
			
 			PlayerPrefs.SetInt("current_level",PlayerPrefs.GetInt("current_level") + 1);
			
			PlayerPrefs.Save();

			fade_script fade = new fade_script();
			
			
        foreach(fade_script f in FindObjectsOfType<fade_script>()){
            if(f.tag == "fader"){
               fade = f;
            } else {
               continue;
            }
        }

			// load map
			     if (Application.CanStreamedLevelBeLoaded("Game"))
     {
		StartCoroutine(GameObject.FindObjectOfType<fade_script>().FadeAndLoadScene(fade_script.FadeDirection.In, "Game"));
	 } else {
		 	StartCoroutine(GameObject.FindObjectOfType<fade_script>().FadeAndLoadScene(fade_script.FadeDirection.In, "Game_mobile"));
	
	 }
			 }
        }
    }
}
