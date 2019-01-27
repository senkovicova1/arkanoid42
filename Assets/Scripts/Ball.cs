using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private float ballInitVelocityX;
    private float ballInitVelocityY;

    private Rigidbody rb;

    private bool ballInPlay;

    public int id;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ballInitVelocityX = Random.Range(300, 1000);
        ballInitVelocityY = Random.Range(300, 1000);
        if (id == 2)
        {
            ballInitVelocityX *= -1;
            ballInitVelocityY *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (id == 2 && Input.GetKeyDown(KeyCode.LeftControl) && !ballInPlay)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitVelocityX, ballInitVelocityY, 0));
        }
        else if (id == 1 && Input.GetKeyDown(KeyCode.RightControl) && !ballInPlay)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitVelocityX, ballInitVelocityY, 0));
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        GameObject ge = collider.gameObject;
        if (ge.tag == "stop")
        {
            ballInitVelocityX = Random.Range(300, 1000);
            ballInitVelocityY = Random.Range(300, 1000);
            if (id == 2)
            {
                ballInitVelocityX *= -1;
                ballInitVelocityY *= -1;
            }

            ballInPlay = false;
            rb.isKinematic = true;
            GM.instance.changeLife(id, -1);
        }
    }

    public void changeVelocity(int times)
    {
        rb.AddForce(new Vector3(ballInitVelocityX*times, ballInitVelocityY*times, 0));
    }
}
