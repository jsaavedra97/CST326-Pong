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
    public Tuple<int, int> score;
    public bool gameover = false;
    [SerializeField] [Range(0, 1000)] private float amplify = 1;
    public ForceMode forceMode;


    // Start is called before the first frame update
    void Start()
    {
        score = new Tuple<int, int>(0,0);

        ballDirection();

		startingPosition = gameObject.transform.position;
        this.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        ballMovement = new Vector3(ballx, 0f, ballz);
	}

    void FixedUpdate()
	{
        moveBall(ballMovement);
	}

    void moveBall(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * ballSpeed * Time.deltaTime));
        Debug.Log("Testing: " + transform.position.x);
        if(transform.position.x > 12 || transform.position.x < -12)
		{
            if(transform.position.x > 12)
			{
                score.Item1++;
			}
            else if(transform.position.x < -12)
			{
                score.Item2++;
			}

            Debug.Log("Player 1 Score: " + score.Item1 + "\nPlayer 2 Score: " + score.Item2);
            
            if(score.Item1 == 11 || score.Item2 == 11)
			{
                gameover = true;
			}
            gameObject.transform.position = startingPosition;
			if(!gameover){ ballDirection(); }
            

        }
    }

    void ballDirection()
	{
        ballx = Random.Range(0, 2) == 0 ? -0.25f : 0.25f;
        ballz = Random.Range(0, 2) == 0 ? -0.25f : 0.25f;
    }

    // Working on this 
    private void OnCollisionEnter(Collision collision)
    {
		//Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
		//if (collision.gameObject.tag == "TeamA")
		//{
		//rb.AddForce(Vector3.up * amplify, forceMode);
		//}

		//if (collision.gameObject.tag == "TeamB")
		//{
		//	Vector3 launchAngle = new Vector3(1, 1, 0) * amplify;
		//    rb.AddForce(launchAngle, forceMode);
		//}

		//Debug.Log(collision.gameObject.name + " hit me");
		moveBall(new Vector3(-ballx, -ballz, 0f));
	}

}
