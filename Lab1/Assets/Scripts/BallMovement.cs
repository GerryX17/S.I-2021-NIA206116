using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;


public class BallMovement : MonoBehaviour
{

	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public TextMeshProUGUI countText;
	public TextMeshProUGUI goalText;
	public GameObject winTextObject;
	public GameObject loseTextObject;
	public GameObject restartButton;

	private float movementX;
	private float movementY;

	private Rigidbody rb;
	AudioSource coin;
	private int count, goals;

	// At the start of the game..
	void Start()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();
		coin = GetComponent<AudioSource>();
		// Set the count to zero 
		count = 0;
		SetCountText();

		// Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
		restartButton.gameObject.SetActive(false);
		winTextObject.SetActive(false);
		loseTextObject.SetActive(false);

	}

	void FixedUpdate()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		Vector3 movement = new Vector3(movementX, 0.0f, movementY);

		rb.AddForce(movement * speed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other)
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);
			coin.Play();

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			countText.text = "Count: " + count.ToString();
			SetCountText();
		}
	}

	private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Porterias")){
			goals++;
			goalText.text = "Goals: " + goals.ToString();
			SetCountText();
		}
		if (collision.gameObject.CompareTag("Equipo1") || collision.gameObject.CompareTag("Equipo2"))
		{
			loseTextObject.SetActive(true);
			restartButton.gameObject.SetActive(true);
		}

	}

	void OnMove(InputValue value)
	{
		Vector2 v = value.Get<Vector2>();

		movementX = v.x;
		movementY = v.y;
	}

	void SetCountText()
	{
		if (count >= 12 && goals >= 1) 
		{
			restartButton.gameObject.SetActive(true);
			loseTextObject.SetActive(false);

			// Set the text value of your 'winText'
			winTextObject.SetActive(true);

		}
	}
}



