using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public GameObject enemy;
	private static PlayerController pl;
	public Transform[] pos;
	public Text st;
	private static int score;
	public Transform bullet_spawn_position;
	public GameObject bullet;
	CharacterController cr;
	private float speed=5f;
	private Vector3 prev_angles;
	// Use this for initialization
	void Start () {
		score = 0;
		cr = this.GetComponent<CharacterController> ();
		pl = this.GetComponent<PlayerController> ();
		pl.enemyspawn ();
		pl.enemyspawn ();
		pl.enemyspawn ();
	}
	
	// Update is called once per frame
	void Update () {
		
		float x_axis = CrossPlatformInputManager.GetAxis("Horizontal");
		float z_axis = CrossPlatformInputManager.GetAxis("Vertical");
		//Debug.Log (x_axis + "  "+ z_axis);
		Vector3 move_details = new Vector3(x_axis * speed * Time.deltaTime, 0, z_axis * speed * Time.deltaTime);
		cr.Move (move_details);
		//angle of the player
		if (x_axis != 0 || z_axis != 0)
		{
			float inputAngle = 90 - (Mathf.Atan2(z_axis, x_axis)) * Mathf.Rad2Deg;

			transform.eulerAngles = Vector3.up * inputAngle;
			prev_angles = transform.eulerAngles;

		}
		else
		{
			transform.eulerAngles = prev_angles;
		}
		st.text = score.ToString ();


	}
	public void instantiate_Bullet()
	{
		GameObject bl = Instantiate(bullet, bullet_spawn_position.position, transform.rotation) as GameObject;
		//shoot_sound.Play();
	}
	public static int getscore()
	{
		return score;
	}
	public static void setscore(int amount)
	{
		score = score + amount;
		pl.enemyspawn ();
	}
	public void enemyspawn()
	{
		int index = Random.Range (0, 1);
		GameObject em = Instantiate (enemy, pos [index].position, Quaternion.identity) as GameObject;
	}
}
