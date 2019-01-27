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
    private bool wasEffective;

    private bool effectActive;

    void Start()
    {
        if (id == 5)
        {
            numberOfHits = 2;
        }
        timeLeft = 0;
        effectActive = false;
        wasEffective = false;
    }

    void Update()
    {
        if (effectActive)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                effectActive = false;
                release();
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (wasEffective) return;
        if (id == 1)
        {
            GM.instance.addAll(transform.position.y);
            wasEffective = true;

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
            if (transform.position.y <= 11.5)
            {
                GM.instance.changeVelocityOfPaddle(1, 2f);
            }
            else
            {
                GM.instance.changeVelocityOfPaddle(2, 2f);
            }
        }
        else if (id == 9)
        {
            if (transform.position.y <= 11.5)
            {
                GM.instance.changeVelocityOfPaddle(1, 0.5f);
            }
            else
            {
                GM.instance.changeVelocityOfPaddle(2, 0.5f);
            }
        }
        else if (id == 10)
        {
            if (transform.position.y <= 11.5)
            {
                GM.instance.enlargeBall(1, 2f);
            }
            else
            {
                GM.instance.enlargeBall(2, 2f);
            }
        }
        else if (id == 11)
        {
            if (transform.position.y <= 11.5)
            {
                GM.instance.enlargeBall(2, 0.5f);
            }
            else
            {
                GM.instance.enlargeBall(1, 0.5f);
            }
        }
        else if (id == 12)
        {
            if (transform.position.y <= 11.5)
            {
                GM.instance.enlargePaddle(1, 2f);
            }
            else
            {
                GM.instance.enlargePaddle(2, 2f);
            }
        }
        else if (id == 13)
        {
            if (transform.position.y <= 11.5)
            {
                GM.instance.enlargePaddle(2, 0.5f);
            }
            else
            {
                GM.instance.enlargePaddle(1, 0.5f);
            }
        }

        timeLeft = 5;
        effectActive = true;
        
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
            if (transform.position.y <= 11.5)
            {
                GM.instance.changeVelocityOfPaddle(1, 0.5f);
            }
            else
            {
                GM.instance.changeVelocityOfPaddle(2, 0.5f);
            }
        }
        else if (id == 9)
        {
            if (transform.position.y <= 11.5)
            {
                GM.instance.changeVelocityOfPaddle(1, 2f);
            }
            else
            {
                GM.instance.changeVelocityOfPaddle(2, 2f);
            }
        }
        else if (id == 10)
        {
            if (transform.position.y <= 11.5)
            {
                GM.instance.enlargeBall(1, 0.5f);
            }
            else
            {
                GM.instance.enlargeBall(2, 0.5f);
            }
        }
        else if (id == 11)
        {
            if (transform.position.y <= 11.5)
            {
                GM.instance.enlargeBall(2, 2f);
            }
            else
            {
                GM.instance.enlargeBall(1, 2f);
            }
        }
        else if (id == 12)
        {
            if (transform.position.y <= 11.5)
            {
                GM.instance.enlargePaddle(1, 0.5f);
            }
            else
            {
                GM.instance.enlargePaddle(2, 0.5f);
            }
        }
        else if (id == 13)
        {
            if (transform.position.y <= 11.5)
            {
                GM.instance.enlargePaddle(2, 2f);
            }
            else
            {
                GM.instance.enlargePaddle(1, 2f);
            }
        }        
    }

}
