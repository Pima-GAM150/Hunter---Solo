using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServeSystem2000 : MonoBehaviour {

    public Text P1Score;
    public Text P2Score;
    int P1scoreInt = 0;
    int P2scoreInt = 0;
    float timer;
    bool serveBall = true;
    bool playerServeBall;

    public Text CountDown;

    public GameObject InvisibleWall;

    public GameObject BallPrefab;

    private GameObject Ball;

    void Start()
    {
        InitiateCountDown();
    }

    void InitiateCountDown()
    {
        timer = 3;
        serveBall = true;
    }
	
    void ServeBall (bool player)
    {
        if (player)
        {
            Ball = Instantiate(BallPrefab, new Vector3(2f,5f,0f), new Quaternion(0f,0f,0f,0f));
            Physics2D.IgnoreCollision(Ball.GetComponent<Collider2D>(), InvisibleWall.GetComponent<Collider2D>());
            Rigidbody2D BallRB = Ball.GetComponent<Rigidbody2D>();
            BallRB.AddForce(new Vector2(.02f,.03f), ForceMode2D.Impulse);
        }
        else
        {
            Ball = Instantiate(BallPrefab, new Vector3(-2f, 5f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            Physics2D.IgnoreCollision(Ball.GetComponent<Collider2D>(), InvisibleWall.GetComponent<Collider2D>());
            Rigidbody2D BallRB = Ball.GetComponent<Rigidbody2D>();
            BallRB.AddForce(new Vector2(-.02f, .03f), ForceMode2D.Impulse);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (timer > 2)
            CountDown.text = "3";
        else if (timer > 1)
            CountDown.text = "2";
        else if (timer > 0)
            CountDown.text = "1";
        else if (serveBall)
        {
            serveBall = false;
            CountDown.text = "";
            ServeBall(playerServeBall);
        }  
        timer -= Time.deltaTime;
        if (!Ball)
            return;
        if (Ball.transform.position.y < 1 && P1scoreInt != 7 && P2scoreInt != 7)
        {
            if (Ball.transform.position.x > 0)
            {
                P1scoreInt++;
                P1Score.text = "P1 Score: " + P1scoreInt;
                playerServeBall = false;
            }
            else
            {
                P2scoreInt++;
                P2Score.text = "P2 Score: " + P2scoreInt;
                playerServeBall = true;
            }
            if (P1scoreInt != 7 && P2scoreInt != 7)
            {
                Destroy(Ball);
                InitiateCountDown();
            }
        }
        else if (P1scoreInt == 7)
            CountDown.text = "Player 1 Wins!";
        else if (P2scoreInt == 7)
            CountDown.text = "Player 2 Wins!";
    }
}
