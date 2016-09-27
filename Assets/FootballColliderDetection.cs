using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FootballColliderDetection : MonoBehaviour
{

	bool lbGoalAchieved;
	public Text gameWonText;
	private ShapesManager gameController;

	 

	// Use this for initialization
	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <ShapesManager>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
		lbGoalAchieved = false;
//		Text  = GameObject.Find("Canvas").GetComponentInChildren<Text>();
//		_currencyText.text = string.Format("{0:0,0.00}", _currency);
		gameController.HideWonText();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Rigidbody2D rb;
		rb = GetComponent<Rigidbody2D> ();

		if (!lbGoalAchieved) {
			int lintRow	= gameObject.GetComponent<Shape> ().Row;

			if (0 == lintRow) {
				int lintColumn	= gameObject.GetComponent<Shape> ().Column;
				if (lintColumn >= 1 && lintColumn <= 4) {
			
					rb.isKinematic = false;

				}
			}
		}

		if (rb.position.y <= -4.5) {
			if (rb.position.x >= -1.2f && rb.position.x <= 1.2) {

				rb.isKinematic = true;
				lbGoalAchieved = true;
				gameController.ShowWonText();
			}
		}


	}

	void OnTriggerEnter2D (Collider2D other)
	{

//		if (other.tag == "Boundary") {
//
//			Rigidbody2D rb;
//			rb = GetComponent<Rigidbody2D> ();
//			rb.isKinematic = true;
//			lbGoalAchieved = true;
//			gameController.ShowWonText();
//
//		}

		//		if (explosion != null)
		//		{
		//			Instantiate(explosion, transform.position, transform.rotation);
		//		}



		//player will not get destoryed
		//Destroy (other.gameObject);
	}
}


/*
public Rigidbody rb;
    void Start() {
        rb = GetComponent<Rigidbody>();
    }
    void EnableRagdoll() {
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }
*/