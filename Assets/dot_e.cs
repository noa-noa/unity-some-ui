using UnityEngine;
using System.Collections;

public class dot_e : MonoBehaviour {
	public GameObject[] dots;
	static float coefficient = 10.7408f * Mathf.Pow(10.0f,(-1.0f));
	Rigidbody2D rb2d;
	float velocity = 5.8f;
	//int flag;
	// Use this for initialization
	void Start () {
		//flag = 1;
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		rb2d.velocity = new Vector2(1.8f,0.0f);
	}
	void gravity(){
		Vector2 direction;
		float distance;
		float gravity;
		Rigidbody2D con;
		dots = GameObject.FindGameObjectsWithTag ("dots");
		Debug.Log (dots.Length);
		if (dots != null) {
			foreach (GameObject rb in dots) {
				con = null;
				con = rb.GetComponent<Rigidbody2D> ();
							Debug.Log (con.mass);
				direction = rb.transform.position - transform.position;
				distance = direction.magnitude;
				if(distance != 0.0f){
					distance *= distance;
				gravity = coefficient * con.mass * rb2d.mass / distance;
			Debug.Log (rb2d.mass + " " + con.mass + " " + coefficient);
				Debug.Log (gravity);
				direction.Normalize ();
				Debug.Log(direction.normalized);

				rb2d.AddForce(gravity*direction,ForceMode2D.Force);
				}
			}
		}
	}
	void jump(){
		rb2d.velocity = new Vector2(2.8f, velocity);
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			jump();
		}
		if (Input.GetKeyDown (KeyCode.Z)) {
			//Instantiate();	
		}
		gravity ();
	
	}
}
