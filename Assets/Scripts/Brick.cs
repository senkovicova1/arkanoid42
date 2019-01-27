using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    
    public GameObject brokenBrick;

    public Material normalBrick;
    public Material partiallyBrokenBrick;
    public Material almostBrokenBrick;
    
    private Rigidbody rb;

    public int id;
    float timeLeft;

    private int numberOfHits;

    private bool released;

    void Start()
    {
        if (id == 5)
        {
            numberOfHits = 2;
        }
        timeLeft = 10;
        released = false;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0 && !released)
        {
            release();
            released = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (id == 1)
        {
            GM.instance.addAll(transform.position.y);

        } else if (id == 2)
        {
            GM.instance.addWall(transform.position.y);
        }
        else if (id == 3)
        {
            if (transform.position.y <= 11.5)
            {
                GM.instance.changeLife(1, 1);
            }
            else
            {
                GM.instance.changeLife(2, 1);
            }
        }
        else if (id == 4)
        {
            if (transform.position.y <= 11.5)
            {
                GM.instance.changeLife(2, -1);
            }
            else
            {
                GM.instance.changeLife(1, -1);
            }
        }
        else if (id == 5)
        {
            if(numberOfHits > 0)
            {
                if (numberOfHits == 2)
                {
                    GetComponent<MeshRenderer>().material = partiallyBrokenBrick;
                } else if (numberOfHits == 1)
                {
                    GetComponent<MeshRenderer>().material = almostBrokenBrick;
                } 
                numberOfHits--;
                return;
            }
            GetComponent<MeshRenderer>().material = normalBrick;
        }
        else if (id == 6)
        {
            if (transform.position.y <= 11.5)
            {
                GM.instance.changeVelocityOfPaddle(2, 2f);
            }
            else
            {
                GM.instance.changeVelocityOfPaddle(1, 2f);
            }
        }
        else if (id == 7)
        {
            if (transform.position.y <= 11.5)
            {
                GM.instance.changeVelocityOfPaddle(2, 0.5f);
            }
            else
            {
                GM.instance.changeVelocityOfPaddle(1, 0.5f);
            }
        }
        else if (id == 8)
        {

        }
        else if (id == 9)
        {

        }
        else if (id == 10)
        {

        }
        else if (id == 11)
        {

        }
        else if (id == 12)
        {

        }
        else if (id == 13)
        {

        }

        timeLeft = 10;
        released = false;

        Instantiate(brokenBrick, transform.position, Quaternion.identity);
        GM.instance.destroyBrick(transform.position.x, transform.position.y);
        
    }



    void release()
    {
        if (id == 6)
        {
            if (transform.position.y <= 11.5)
            {
                GM.instance.changeVelocityOfPaddle(2, 0.5f);
            }
            else
            {
                GM.instance.changeVelocityOfPaddle(1, 0.5f);
            }
        }
        else if (id == 7)
        {
            if (transform.position.y <= 11.5)
            {
                GM.instance.changeVelocityOfPaddle(2, 2f);
            }
            else
            {
                GM.instance.changeVelocityOfPaddle(1, 2f);
            }
        }
        else if (id == 8)
        {

        }
        else if (id == 9)
        {

        }
        else if (id == 10)
        {

        }
        else if (id == 11)
        {

        }
        else if (id == 12)
        {

        }
        else if (id == 13)
        {

        }
    }

}
