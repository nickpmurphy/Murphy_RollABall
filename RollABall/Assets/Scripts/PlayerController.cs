using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;



public class PlayerController : MonoBehaviour
{
    public float speed = 0;
		public TextMeshProUGUI countText;
		public GameObject winTextObject;
		public GameObject loseTextObject;
		public TextMeshProUGUI timeCountText;

    private Rigidbody rb;
		private int count;
    private float movementX;
    private float movementY;

		private float elapsed;

		public float jumpPower;

		// bool to check if player is on the ground or not
		bool onGround = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
				count = 0;

				SetCountText();
				winTextObject.SetActive(false);
				loseTextObject.SetActive(false);

    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

		void SetCountText()
		{

			countText.text = "Count: " + count.ToString();
			if(count >= 12) {
				winTextObject.SetActive(true);
				loseTextObject.SetActive(false);
			}
		}

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

		void Update() {

			// variable to store time
			elapsed += Time.deltaTime;

			// assigning timeCount object
			timeCountText.text = "Time elapsed: " + Mathf.FloorToInt(elapsed).ToString();

			// variable updating every frame to update bool if on ground or not
			onGround = Physics.Raycast(transform.position, Vector3.down, .51f);

		}

		void OnJump() {
			Jump();
		}

		void Jump() {

			// checks to make sure player is not already in the air before jumping again
			if(onGround)

				// apply force to player to "jump"
				rb.AddForce(Vector3.up * jumpPower);
		}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
						count = count +1;

						SetCountText();

        }

				// same as above, checking tag of object collision
				if(other.gameObject.CompareTag("Dead"))
				{
					// delete cube
					other.gameObject.SetActive(false);

						// display losing text
						loseTextObject.SetActive(true);
						winTextObject.SetActive(false);


				}
    }
}
