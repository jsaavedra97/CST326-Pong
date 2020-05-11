using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float ballSpeed;
    public Rigidbody rb;


    private int leftScore  = 0;
    private int rightScore = 0;
    public float tempSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Debug.Log(rb.position);
        moveBall();
        tempSpeed = ballSpeed;
    }


    void moveBall()
    {
        float ballx = Random.Range(0, 2) == 0 ? -1f : 1f;
        float ballz = Random.Range(0, 2) == 0 ? -1f : 1f;
        rb.velocity = new Vector3(ballSpeed * ballx, 0, ballSpeed * ballz);
    }

    void ballDirection(bool leftScored)
	{
        // Resets attributes of Ball
        tempSpeed = ballSpeed;
        rb.transform.localScale = new Vector3(1, 1, 1);
        rb.position = new Vector3(0f, 0.5f, 0f);

        // Keeps track of score
        Debug.Log("Left Score: " + leftScore + " Right Score: " + rightScore);

        // Checks to see if game ended
		if (leftScore == 3 || rightScore == 3)
            Destroy(this);

        float ballx = Random.Range(0, 2) == 0 ? -1f : 1f;
        //float ballz = Random.Range(0, 2) == 0 ? -1f : 1f;

        // My attempt at forcing the ball's direction after scoring
        if (leftScored)
            rb.velocity = new Vector3(ballSpeed * ballx, 0, ballSpeed);

        else
            rb.velocity = new Vector3(ballSpeed * ballx, 0, ballSpeed * -1);

    }


    void OnCollisionEnter(Collision collision)
    {
        // Increases the Ball Speed
		if (collision.gameObject.tag == "Paddle")
		{
            tempSpeed += 0.000025f;
            if (collision.gameObject.name == "PaddleRight")
                rb.AddForce(transform.right * tempSpeed, ForceMode.Impulse);

            if (collision.gameObject.name == "PaddleLeft")
                rb.AddForce(transform.right * -tempSpeed, ForceMode.Impulse); ;
        }

        if (collision.gameObject.name == "Left Goal")
		{
            rightScore++;
            ballDirection(false);
		}

		if (collision.gameObject.name == "Right Goal")
		{
            leftScore++;
            ballDirection(true);
		}


	}

}
