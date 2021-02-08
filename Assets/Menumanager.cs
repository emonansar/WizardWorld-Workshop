using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menumanager : MonoBehaviour {
	public Text h;

	// Use this for initialization
	void Start () {
		h.text = PlayerPrefs.GetInt ("high").ToString();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void play_game()
	{
		SceneManager.LoadScene (1);
	}
}
