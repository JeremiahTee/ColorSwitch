using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public string currentColor;
	public float jumpForce = 10f;
	public Rigidbody2D circle;
	public SpriteRenderer sr;
	public Color blue, yellow, pink, purple;
	// Use this for initialization
	void Start () {
		setRandomColor ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)){
			circle.velocity = Vector2.up * jumpForce;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision){
		if (collision.tag == "ColorChanger") {
			setRandomColor ();
			Destroy (collision.gameObject);
			return;
		}

		if (collision.tag != currentColor) {
			Debug.Log ("You died!");
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex); //reload index
		}
	}

	void setRandomColor(){
		int rand = Random.Range (0, 4);
		switch (rand) {
		case 0:
			currentColor = "Blue";
			sr.color = blue;
			break;
		case 1:
			currentColor = "Yellow";
			sr.color = yellow;
			break;
		case 2:
			currentColor = "Pink";
			sr.color = pink;
			break;
		case 3:
			currentColor = "Purple";
			sr.color = purple;
			break;
		}
	}
}
