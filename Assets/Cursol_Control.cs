using UnityEngine;
using System.Collections;

public class Cursol_Control : MonoBehaviour {
	public Transform black_dot;
	public Transform red_dot;
	public int flag;
	public Vector2 position;
	public Transform ball;

	GameObject dotl;
	int linenum;
	Vector2 preposition;
	int dotnum;

//	MovingBall ball;

	static float d = 0.09f;

	// Use this for initialization
	void Start () {
		flag = 0;
		dotnum = 0;
		linenum = 0;
	}
	
	// Update is called once per frame
	void Update () {
		trace ();
		
		if (Input.GetMouseButtonDown (0)) {
			linebegin ();
		}
		if (dotl == null && flag == 1) {
			flag = 0;
		}
		if (flag == 1) {
			float distance;
			distance = (position - preposition).magnitude;
			if (distance > d) {
				correct (distance);
			}
			if (distance > 0.0f) {
				clone (black_dot, position);
			}
			preposition = position;
		}
		if(Input.GetMouseButtonUp (0) && flag==1) {
			linefin ();
		}
		if(Input.GetKeyDown (KeyCode.Z))
			Instantiate (ball, position, ball.transform.rotation);
	}

	void linebegin(){
		flag = 1;
		dotl = new GameObject ("char" + linenum);
		dotl.AddComponent<LineObj>();
		linenum++;
		clone (black_dot, transform.position);
		preposition = position;
	}
	void linefin(){
		Rigidbody2D rb2d;
		flag = 0;
		dotl.AddComponent<Rigidbody2D> ();
		rb2d = dotl.GetComponent<Rigidbody2D> ();
		rb2d.mass = dotl.transform.childCount;
		dotl.SendMessage ("Created");
		dotl = null;
	}
	public void linedes(){
		flag = 0;
		dotl = null;
	}
	void clone(Transform dot,Vector2 pos){
		Transform clone = (Transform)Instantiate (dot, pos, dot.rotation);
		Debug.Log ("hey");
		clone.transform.parent = dotl.transform;
		dotnum++;
	}
	void correct(float distance){
		int num = (int)(distance / d);
		Vector2 pushpos = preposition;
		Vector2 dxy = new Vector2((position.x - preposition.x) / num,(position.y - preposition.y) / num);
		for (int i=0; i<num; i++) {
			pushpos += dxy;
			clone(black_dot,pushpos);
		}
	}
	void trace(){
		position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		this.transform.position = position;
		if (position.x < 5.51f && -2.2f < position.y) {

		} else {
			position = preposition;
		}
	}

}
