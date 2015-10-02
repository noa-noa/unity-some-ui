using UnityEngine;
using System.Collections;

public class MovingBall : MonoBehaviour {
	Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		rb2d.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		rb2d.velocity = new Vector2 (-8.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
