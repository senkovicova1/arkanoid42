using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2 : MonoBehaviour {

    public static Ball2 instance = null;
    
    private Rigidbody rb;

    public GameObject brokenBall;

    public bool ballInPlay;

    public int id;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.LeftControl) && !ballInPlay)
        {
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(0, 800, 0));
        }

        if (!ballInPlay)
        {
            float xPos = 0;

            if (Input.GetKey(KeyCode.W))
            {
                xPos = transform.position.x + Paddle2.instance.paddleSpeed;
                transform.position = new Vector3(Mathf.Clamp(xPos, -9.5f, 9.5f), transform.position.y, transform.position.z);
            }

            if (Input.GetKey(KeyCode.S))
            {
                xPos = transform.position.x - Paddle2.instance.paddleSpeed;
                transform.position = new Vector3(Mathf.Clamp(xPos, -9.5f, 9.5f), transform.position.y, transform.position.z);
            }
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        GameObject ge = collider.gameObject;
        if (ge.tag == "stop")
        {
            Instantiate(brokenBall, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            ballInPlay = false;
            rb.isKinematic = true;
            GM.instance.changeLife(id, -1);
        }
    }

    public void changeSize(float times)
    {
        rb.transform.localScale = new Vector3(rb.transform.localScale.x * times, rb.transform.localScale.y * times, rb.transform.localScale.z * times);
    }

    public void setKinematic(bool set)
    {
        rb.isKinematic = set;
    }
}
