using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {
	
	static float timer = 0.0f;
	public Text text_box;
	public bool isRunning = false;
	Vector3 startPosition;
	public CharacterController characterController;

	// Use this for initialization
	void Start () {

		startPosition = characterController.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

				if (isRunning) {
						timer += Time.deltaTime;
						text_box.text = timer.ToString ("0.00");
				}

				if (!isRunning & Input.GetKeyDown (KeyCode.F)) {
						isRunning = true;
				}

	}
	/* We want to check when the character collides with a trigger object, 
	   in this case, the particle system cylinder that ends the run. */
	void OnTriggerEnter(Collider other)
	{
		Reset ();
	}

	/* Call Reset once we start the game over. */
	void Reset()
	{
		characterController.gameObject.transform.position = startPosition;
		isRunning = false;
		timer = 0.0f;
		text_box.text = "Press 'F' to begin";
	}
}
