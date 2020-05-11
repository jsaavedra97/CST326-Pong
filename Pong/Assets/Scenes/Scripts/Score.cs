using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text rightScoreKeeper;
    public Text leftScoreKeeper;
    public Text gameOver;

    public GameObject ball;

    public bool isRightGoal;
    private int rightScore = 0;
    private int leftScore  = 0;

    // Update is called once per frame
    void Start()
    {
        rightScoreKeeper.text = rightScore.ToString();
        leftScoreKeeper.text = leftScore.ToString();
    }

    void FixedUpdate()
	{
        if (rightScore == 3 || leftScore == 3)
        {
            rightScoreKeeper.text = (0).ToString();
            leftScoreKeeper.text = (0).ToString();
            gameOver.text = "Game Over!\n" + (rightScore == 3 ? "Left " : "Right ") + " Paddle Wins!";
            Destroy(ball);
        }
    }

    void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.name == "Ball")
		{
			if (isRightGoal)
			{
                rightScoreKeeper.text = (++rightScore).ToString();
                rightScoreKeeper.color = rightScore % 2 == 0 ? Color.red : Color.green;

            }

            else
			{
                leftScoreKeeper.text = (++leftScore).ToString();
                leftScoreKeeper.color = leftScore % 2 == 0 ? Color.yellow : Color.blue;

            }
        }
	}
}
