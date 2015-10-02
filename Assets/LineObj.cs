using UnityEngine;
using System.Collections;

public class LineObj : MonoBehaviour {
	GameObject go;
	// Use this for initialization
	void Start () {
		state = STATE.Creating;
	}
	enum STATE{
		Creating,
		Created
	}
	STATE state;
	// Update is called once per frame
	void Update () {
	
	}
	void Created(){
		state = STATE.Created;
		Collider2D[] cols = GetComponentsInChildren<Collider2D> ();
		Debug.Log (cols);
		foreach (Collider2D co in cols) {
			Debug.Log(co);
			co.isTrigger = false;
		}
	}
	void OnCollisionEnter2D(Collision2D col){
	}
	void ChildCollision(string name){
		if (state == STATE.Creating && name != "blackdot") {
			Destroy (this.gameObject);
		} else if (state == STATE.Creating) {
		
		}
	}
}
