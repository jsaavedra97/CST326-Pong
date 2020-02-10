using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{

    public bool isLeftPaddle;
    public bool isRightPaddle;
    public float paddleMovement = 25f;

    public AudioSource paddleSoundLeft;
    public AudioSource paddleSoundRight;


    void Start()
	{
        paddleSoundLeft = GetComponent<AudioSource>();
        paddleSoundRight = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
		if (isLeftPaddle){
			transform.Translate(0f, 0f, Input.GetAxis("Player1") * paddleMovement * Time.deltaTime);
			//Debug.Log("Left Paddle position: " + Input.GetAxis("Player1") * paddleMovement * Time.deltaTime);
		}
		if (isRightPaddle){
            transform.Translate(0f, 0f, Input.GetAxis("Player2") * paddleMovement * Time.deltaTime);
            //Debug.Log("Right Paddle position: " + Input.GetAxis("Player2") * paddleMovement * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
	{
		if (isLeftPaddle)
		{
            paddleSoundLeft.Play();
		}
		if (isRightPaddle)
		{
            paddleSoundRight.Play();
		}
	}
}
