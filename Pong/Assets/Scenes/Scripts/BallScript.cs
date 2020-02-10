using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float ballSpeed = 10.0f;
    public Rigidbody rb;

    public Vector3 ballMovement;
    public Vector3 startingPosition;
    public float ballx;
    public float ballz;
    public int[] score;
    public bool gameover = false;
    [SerializeField] [Range(0, 1000)] private float amplify = 10;
    [SerializeField] private float step;

    public ForceMode forceMode;


    // Start is called before the first frame update
    void Start()
    {
        score = new int[] { 0, 0 };

        ballDirection();

		startingPosition = gameObject.transform.position;
        //this.GetComponent<Rigidbody>();
        rb = gameObject.GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().velocity = new Vector3(ballSpeed * ballx, 0f, ballSpeed * ballz);
    }

    // Update is called once per frame
    void Update()
    {
        while(ballx == ballz && ballx == 0)
		{
            ballDirection();
		}
        ballMovement = new Vector3(ballx + 0.01f, 0f, ballz);
	}

    

    void FixedUpdate()
	{
        moveBall(ballMovement);
	}

    void moveBall(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * ballSpeed * Time.deltaTime));
        //Debug.Log("Testing: " + transform.position.x);
        if(transform.position.x > 12 || transform.position.x < -12)
		{
            if(transform.position.x > 12)
			{
                score[0]++;
			}
            else if(transform.position.x < -12)
			{
                score[1]++;
			}

            Debug.Log("Player 1 Score: " + score[0] + "\nPlayer 2 Score: " + score[1]);
            
            if(score[0] == 3 || score[1] == 3)
			{
                //gameover = true;
                Debug.Log("Player " + (score[0] == 3 ? "1" : "2") + " wins!");
                
			}
            gameObject.transform.position = startingPosition;
            ballDirection();


        }
    }

    void ballDirection()
	{
        ballx = Random.Range(0, 2) == 0 ? -0.5f : 0.5f;
        ballz = Random.Range(0, 2) == 0 ? -0.5f : 0.5f;
    }

    void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.name == "PaddleLeft" || collision.gameObject.name == "PaddleRight")
        {
            //play sound

            Debug.Log("Paddle Hit");
            amplify += step;
            float offset = Mathf.Pow((transform.position.z - collision.transform.position.z), 2);
            offset = (transform.position.z - collision.transform.position.z < 0) ? offset * -1 : offset;

            rb.velocity = (collision.gameObject.name == "PaddleLeft") ? new Vector3(amplify, 0, offset) : new Vector3(-amplify, 0, offset);
        }


        if(collision.gameObject.tag == "PowerUp")
        {
            ballSpeed *= 3.0f;
            Debug.Log("Ball Collided with me");
            Destroy(collision.gameObject);
        }

        /*if(collision.gameObject.name == "UpperWall" || collision.gameObject.name == "LowerWall") {
            Debug.Log("Wall Hit");
            amplify += step;
            float offset = Mathf.Pow((transform.position.z - collision.transform.position.z), 2);
            offset = (transform.position.z - collision.transform.position.z < 0) ? offset * -1 : offset;

            rb.velocity = (collision.gameObject.name == "UpperWall") ? new Vector3(-offset, 0, amplify) : new Vector3(-offset, 0, -amplify);
        }*/
    }

}
