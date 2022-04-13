using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow_player : MonoBehaviour {


	public Player_Controller player_controller;

    public Vector3 offset;         

	void Start () {
		

		if(player_controller != null){

		
		player_controller = FindObjectOfType<Player_Controller>();
		offset =new Vector3(-1,0,-4) ;
		}
	}
	
	void Update () {
		if(player_controller != null)
		 transform.position = player_controller.transform.position + offset;
	}
}
