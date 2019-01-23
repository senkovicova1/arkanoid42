using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle1 : MonoBehaviour {

    public float paddle1Speed = 1f;
        
    private Vector3 paddle1Position = new Vector3(0f, -8f, 0f);



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float xPos = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            xPos = transform.position.x +  paddle1Speed;
            paddle1Position = new Vector3(Mathf.Clamp(xPos, -12f, 12f), -8f, 0f);
            transform.position = paddle1Position;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            xPos = transform.position.x - paddle1Speed;
            paddle1Position = new Vector3(Mathf.Clamp(xPos, -12f, 12f), -8f, 0f);
            transform.position = paddle1Position;
        }    

    }
}
