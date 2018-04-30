using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

	public Transform Player;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if player has passed camera position
		if (Player.position.y > transform.position.y) {
			//make camera follow player exactly on y-axis
			transform.position = new Vector3 (transform.position.x, Player.position.y, transform.position.z);
		}
	}
}
