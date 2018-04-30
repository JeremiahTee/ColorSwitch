using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public string currentColor;
	public float jumpForce = 10f;
	public Rigidbody2D circle;
	public GameObject[] obstacle;
	public SpriteRenderer sr;
	public Color blue, yellow, pink, purple;
	public static int score = 0;
	public Text scoreText;

	//Singleton, class that will only ever have one instance during scene
	public static Player instance;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		setRandomColor ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)){
			circle.velocity = Vector2.up * jumpForce;
		}
		if (instance.transform.position.y < -100f) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex); //reload index
		}
		scoreText.text = score.ToString(); //convert int to string
	}

	private void OnTriggerEnter2D(Collider2D collision){
		if (collision.tag == "Scored") {
			score++;
			setRandomColor ();
			Destroy (collision.gameObject);
			int rand = Random.Range (0, 2);
			if (rand == 0) {
				Instantiate (obstacle[0], new Vector2(transform.position.x, transform.position.y + 7f), transform.rotation);
			} else {
				Instantiate (obstacle[1], new Vector2(transform.position.x, transform.position.y + 7f), transform.rotation);
			}
			return;
		}

		if (collision.tag != currentColor) {
			Debug.Log ("You died!");
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex); //reload index
			score = 0; //reset score
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
