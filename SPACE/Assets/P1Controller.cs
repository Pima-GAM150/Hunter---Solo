using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Controller : MonoBehaviour {

    public float speed = 5;
    public float jumpHeight = 10;

    public Rigidbody2D player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //player.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime,0f),ForceMode2D.Impulse);
        if (Input.GetKey(KeyCode.LeftArrow))
            player.AddForce(new Vector2(-speed, 0f), ForceMode2D.Force);
        if (Input.GetKey(KeyCode.RightArrow))
            player.AddForce(new Vector2(speed, 0f), ForceMode2D.Force);
        if (Input.GetKeyDown(KeyCode.UpArrow))
            if (player.position.y < 1 )
                player.AddForce(new Vector2(0f,jumpHeight),ForceMode2D.Impulse);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            if (player.position.y > 3)
                player.AddForce(new Vector2(0f, -jumpHeight), ForceMode2D.Impulse);
	}
}
