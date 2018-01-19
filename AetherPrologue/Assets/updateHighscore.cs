using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateHighscore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("score"))
        {
            gameObject.GetComponent<Text>().text += PlayerPrefs.GetInt("score");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
