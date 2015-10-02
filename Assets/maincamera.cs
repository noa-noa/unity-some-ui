using UnityEngine;
using System.Collections;

public class maincamera : MonoBehaviour {
	public GameObject[] dots;
	// Use this for initialization
	void Start () {
		dots = GameObject.FindGameObjectsWithTag ("dots");
	}
	
	// Update is called once per frame
	void Update () {
		cameraposi ();
		if (65.0f < transform.position.x) {
			Application.LoadLevel(0);
		}
	}
	void cameraposi(){
		float maxX=0.0f;
		float y=0.0f;
		foreach (GameObject rb in dots) {
			if(maxX<rb.transform.position.x){
				maxX = rb.transform.position.x;
				y = rb.transform.position.y;
			}
			gameObject.transform.position = new Vector3(maxX,y,transform.position.z);
		}
	}

}
