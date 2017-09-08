using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Controller : MonoBehaviour {

    public float speed = 5;
    public float jumpHeight = 10;
    private float keyPress = 0;

    public Rigidbody2D player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            keyPress++;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            keyPress++;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.AddForce(new Vector2(-speed, 0f), ForceMode2D.Force);
            if (keyPress > 1)
            {
                player.AddForce(new Vector2(-4f, 0f), ForceMode2D.Impulse);
                keyPress = 0;
            }
        }     
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.AddForce(new Vector2(speed, 0f), ForceMode2D.Force);
            if (keyPress > 1)
            {
                player.AddForce(new Vector2(4f, 0f), ForceMode2D.Impulse);
                keyPress = 0;
            }
        }          
        if (Input.GetKeyDown(KeyCode.UpArrow) && player.position.y < 1)
            player.AddForce(new Vector2(0f,jumpHeight),ForceMode2D.Impulse);
        if (Input.GetKeyDown(KeyCode.DownArrow) && player.position.y > 3)
            player.AddForce(new Vector2(0f, -jumpHeight), ForceMode2D.Impulse);

        if (keyPress > 0)
            keyPress -= 1 * Time.deltaTime;
	}
}
