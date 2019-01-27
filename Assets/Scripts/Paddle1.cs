using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle1 : MonoBehaviour {

    public float paddleSpeed = 0.5f;

    public static Paddle1 instance = null;

    // Use this for initialization
    void Start () {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        float xPos = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            xPos = transform.position.x + paddleSpeed;
            transform.position = new Vector3(Mathf.Clamp(xPos, -9.5f, 9.5f), transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            xPos = transform.position.x - paddleSpeed;
            transform.position = new Vector3(Mathf.Clamp(xPos, -9.5f, 9.5f), transform.position.y, transform.position.z);
        }    

    }
}
