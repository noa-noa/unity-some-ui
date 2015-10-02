using UnityEngine;
using System.Collections;

public class Monster_Azarashi : MonoBehaviour {
//	Rigidbody2D rb2d;
//	private bool isIdle = true;
	private int motion;
	int time;
	private int dir = 1;
	// Use this for initialization
	void Start () {
//		rb2d = gameObject.GetComponent<Rigidbody2D> ();
	}
	void hopping(){
	//	gameObject.transform.position += new Vector2(3.0f * Time.deltaTime, 3.0f * Time.deltaTime);
	}
	void walking(){
		transform.position = new Vector2(transform.position.x + dir*3.0f * Time.deltaTime, transform.position.y);
	}
	// Update is called once per frame
	void Update () {
	/*	if (isIdle) {
			motion = Random.Range (0, 0);
			time = Random.Range(3,8);
			isIdle = !isIdle;
		} else {
			if(motion == 0){
				hopping();
			}
			if(motion == 1){
				walking();
			}

		}*/
		walking ();
	
	}
	void OnCollisionEnter2D(Collision2D col){
		dir *= -1;
	}
}
