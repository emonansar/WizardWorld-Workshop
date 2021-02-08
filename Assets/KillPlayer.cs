using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class KillPlayer : MonoBehaviour {
	NavMeshAgent nv;
	private GameObject player;
	// Use this for initialization
	void Start () {
		nv=this.GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {
		nv.destination = player.transform.position;

	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player") {
			if (PlayerController.getscore () > PlayerPrefs.GetInt ("high")) 
			{
				PlayerPrefs.SetInt ("high", PlayerController.getscore ());
			}
			SceneManager.LoadScene (0);
		}
	}
}
