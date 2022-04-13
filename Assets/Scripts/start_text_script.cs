using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class start_text_script : MonoBehaviour {


	private Text text;

	void Start () {
		text = GetComponent<Text>();
		text.text = "LEVEL " + PlayerPrefs.GetInt("current_level").ToString();
	}
	
	void Update () {
		
	}
}
