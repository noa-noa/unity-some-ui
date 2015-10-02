using UnityEngine;
using System.Collections;

public class blackdot : MonoBehaviour {
	public GameObject[] planets;
	public float accelaration;
	static float coefficient = 6.67408f * Mathf.Pow(10.0f,(-2.0f));
	Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		accelaration = 9.8f;
		Debug.Log (coefficient);
	}
	
	// Update is called once per frame
	void Update () {

	}
	void gravity(){
		Vector2 direction;
		float distance;
		float gravity;
		Rigidbody2D con;
		planets = GameObject.FindGameObjectsWithTag("purple");
		
		foreach (GameObject rb in planets) {
			con = rb.GetComponent<Rigidbody2D>();
			//			Debug.Log (con.mass);
			direction = rb.transform.position - transform.position;
			distance = direction.magnitude;
			distance *= distance;
			gravity = coefficient*con.mass*rb2d.mass/distance;
			Debug.Log(rb2d.mass+" "+con.mass+" "+coefficient);
			//			direction.Normalize();
			rb2d.AddForce (gravity * direction.normalized, ForceMode2D.Force);
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		//transform.parent.SendMessage ("ChildCollision",SendMessageOptions.DontRequireReceiver);
	}
	void OnTriggerEnter2D(Collider2D col){
		transform.parent.SendMessage ("ChildCollision", col.name);

//		col.isTrigger != col.isTrigger;
	}

}
