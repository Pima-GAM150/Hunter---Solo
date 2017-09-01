using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {

    public Collider2D ball;

    public Collider2D wall;

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreCollision(ball, wall);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
