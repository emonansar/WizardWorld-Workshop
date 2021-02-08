using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
	Rigidbody rb;

	private float force_amount = 1500f;

	// Use this for initialization
	void Start () {
		rb=this.GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce (transform.forward * force_amount * Time.deltaTime);
		Destroy(this.gameObject, .50f);
		
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			PlayerController.setscore (1);
			Destroy (col.gameObject);
		}
	}
}
