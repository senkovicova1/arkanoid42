using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {

    public GameObject text;

    //lives amount
    public int lives1x;
    public int lives2x;

    //coords of life balls in the game
    public float[] livesPl1Coords;// = new float[] { -7f, 0f, 7f, 0.5f, 3f};
    public float[] livesPl2Coords;// = new float[] { 35.5f, 33f, 30.5f, 28f, 25.5f };

    //array of lives - will be made (in)visible if player looses/gains life
    public GameObject[] life1Array;
    public GameObject[] life2Array;

    //prefabs of Life ball
    public GameObject life1Prefab;
    public GameObject life2Prefab;

    //lives amount
    private int bricksAmount1;
    private int bricksAmount2;

    /*array with bricks 
     * 0 = no brick 
     * 1 = normal brick
     * 2 = special brick
     */
    private GameObject[][] bricks1;
    private GameObject[][] bricks2;
    private GameObject[] addedBricks1;
    private GameObject[] addedBricks2;

    //prefab of brick and broken brick
    public GameObject brokenBrick;
    
    public GameObject brickPrefab;
    public GameObject brickPrefab1;
    public GameObject brickPrefab2;
    public GameObject brickPrefab3;
    public GameObject brickPrefab4;
    public GameObject brickPrefab5;
    public GameObject brickPrefab6;
    public GameObject brickPrefab7;
    public GameObject brickPrefab8;
    public GameObject brickPrefab9;
    public GameObject brickPrefab10;
    public GameObject brickPrefab11;
    public GameObject brickPrefab12;
    public GameObject brickPrefab13;

    //sign with texts - Player1 won/Player2 won
    public GameObject GOPl1;
    public GameObject GOPl2;
    private bool visibleEnd = false;

    //player1
    public GameObject paddle1;
    public GameObject ball1;
    public GameObject brokenBall1;

    //player2
    public GameObject paddle2;
    public GameObject ball2;
    public GameObject brokenBall2;

    public static GM instance = null;  
    

    // Use this for initialization
    void Start () {
		if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
        setupGame();
	}

    public void setupGame()
    {

        //instantiate bricks on p1 side
        float offsetY = 0.5f;
        float offsetX = 2.5f;

        float x = -11.5f + 1.5f;
        float y = 11.5f - offsetY - 1;

        bricks1 = new GameObject[5][];
        bricksAmount1 = 45;
        for (int i = 0; i < 5; i++)
        {
            
            bricks1[i] = new GameObject[9];
            for (int j = 0; j < 9; j++)
            {                
                bricks1[i][j] = Instantiate(brickPrefab6, new Vector3(x, y, 0), Quaternion.identity);
                x += offsetX;
            }
            y -= offsetY + 1;
            x = -11.5f + 1.5f;
        }

        //instantiate bricks on p2 side
        x = -10f;
        y = 13f;

        bricks2 = new GameObject[5][];
        bricksAmount2 = 45;
        for (int i = 0; i < 5; i++)
        {

            bricks2[i] = new GameObject[9];
            for (int j = 0; j < 9; j++)
            {
                bricks2[i][j] = Instantiate(brickPrefab6, new Vector3(x, y, 0), Quaternion.identity);
                x += offsetX;
            }
            y += offsetY + 1;
            x = -10f;
        }



        life1Array = new GameObject[5];
        life2Array = new GameObject[5];

        lives1x = 3;
        lives2x = 3;

        //instantiate lives
        for (int ii = 0; ii < 5; ii++)
        {
            life1Array[ii] = Instantiate(life1Prefab, new Vector3(-12f, livesPl1Coords[ii], -1), Quaternion.identity);                        
            life2Array[ii] = Instantiate(life2Prefab, new Vector3(-12f, livesPl2Coords[ii], -1), Quaternion.identity);
            if (ii >= 3)
            {
                life1Array[ii].SetActive(false);
                life2Array[ii].SetActive(false);
            }
        }
        
    }

    void checkGO()
    {
        if (lives1x == -1 || bricksAmount2 == 0)
        {
            if (addedBricks2 != null)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (addedBricks2[i].activeInHierarchy) return;
                }
            }
            GOPl1.SetActive(true);
            visibleEnd = true;
        } else if (lives2x == -1 || bricksAmount1 == 0)
        {
            if (addedBricks1 != null)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (addedBricks1[i].activeInHierarchy) return;
                }
            }
            GOPl2.SetActive(true);
            text.GetComponent<UnityEngine.UI.Text>().text = "meh";
            visibleEnd = true;
        }
    }

    public void changeLife(int player, int life)
    {
        if (player == 1)
        {
            lives1x += life;
            if (life < 0)
            {
                Instantiate(brokenBall1, new Vector3(ball1.transform.position.x, ball1.transform.position.y, 0), Quaternion.identity);
                ball1.transform.parent = paddle1.transform;
                ball1.transform.position = new Vector3(paddle1.transform.position.x, paddle1.transform.position.y + 1, 0);

                for (int i = 0; i < 5; i++)
                {
                    if (life1Array[4 - i].activeInHierarchy)
                    {
                        life1Array[4 - i].SetActive(false);
                        return;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    if (!life1Array[i].activeInHierarchy)
                    {
                        life1Array[i].SetActive(true);
                        return;
                    }
                }
            }
        } else
        {
            lives2x += life;
            if (life < 0)
            {
                Instantiate(brokenBall2, new Vector3(ball2.transform.position.x, ball2.transform.position.y, 0), Quaternion.identity);
                ball2.transform.parent = paddle2.transform;
                ball2.transform.position = new Vector3(paddle2.transform.position.x, paddle2.transform.position.y - 1, 0);

                for (int i = 0; i < 5; i++)
                {
                    if (life2Array[4 - i].activeInHierarchy)
                    {
                        life2Array[4 - i].SetActive(false);
                        return;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    if (!life2Array[i].activeInHierarchy)
                    {
                        life2Array[i].SetActive(true);
                        return;
                    }
                }
            }
        }
        checkGO();
    }
    

    public void destroyBrick(float x, float y)
    {
        int xx = (int)((x + 10f) / 2.5f);
        int yy = (int)((10f - y) / 1.5f);

        if (y == 1f)
        {
            addedBricks1[xx].SetActive(false);
        } else if (y == 22.5f)
        {
            addedBricks2[xx].SetActive(false);
        } else if (y <= 11f)
        {
            bricks1[yy][xx].SetActive(false);
            bricksAmount1--;
        } else
        {         
            bricks2[yy*(-1)-2][xx].SetActive(false);
            bricksAmount2--;
        }
        checkGO();        
    }

    void Update()
    {
        if (visibleEnd && Input.GetKey(KeyCode.KeypadEnter))
        {
            visibleEnd = false;
            GOPl1.SetActive(false);
            GOPl2.SetActive(false);

            paddle1.transform.position = new Vector3(0, -8, 0);
            ball1.transform.parent = paddle1.transform;
            ball1.transform.position = new Vector3(paddle1.transform.position.x, paddle1.transform.position.y + 1, 0);

            paddle2.transform.position = new Vector3(0, 31f, 0);
            ball2.transform.parent = paddle2.transform;
            ball2.transform.position = new Vector3(paddle2.transform.position.x, paddle2.transform.position.y - 1, 0);

            Paddle1.instance.paddleSpeed = 0.5f;
            Paddle2.instance.paddleSpeed = 0.5f;

            Start();
        }   
    }

    public void addAll(float y)
    {
        if (y < 11.5f)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    bricks2[i][j].SetActive(true);
                }
            }
            bricksAmount2 = 45;
        } else
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    bricks1[i][j].SetActive(true);
                }
            }
            bricksAmount1 = 45;
        }
    }

    public void addWall(float y)
    {
        if (y < 11.5f)
        {
            if (addedBricks2 == null)
            {
                addedBricks2 = new GameObject[9];
                float offsetX = 2.5f;
                float x = -10f;
                for (int i = 0; i < 9; i++)
                {
                    addedBricks2[i] = Instantiate(brickPrefab, new Vector3(x, 22.5f, 0), Quaternion.identity);
                    x += offsetX;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                addedBricks2[i].SetActive(true);
            }
        } else
        {
            if (addedBricks1 == null)
            {
                addedBricks1 = new GameObject[9];
                float offsetX = 2.5f;
                float x = -10f;
                for (int i = 0; i < 9; i++)
                {
                    addedBricks1[i] = Instantiate(brickPrefab, new Vector3(x, 1, 0), Quaternion.identity);
                    x += offsetX;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                addedBricks1[i].SetActive(true);
            }
        }
    }

    public void changeVelocityOfPaddle(int id, float times)
    {
        if (id == 1)
        {
            if ((Paddle1.instance.paddleSpeed > 4 && times > 1f)
                || (Paddle1.instance.paddleSpeed < 0.2 && times < 1f))
                return;

            float old = Paddle1.instance.paddleSpeed;
            Paddle1.instance.paddleSpeed *= times;
            text.GetComponent<UnityEngine.UI.Text>().text = old + "*" + times + "=" + Paddle1.instance.paddleSpeed + " paddle1";
        } else
        {
            if ((Paddle2.instance.paddleSpeed > 4 && times > 1f)
                || (Paddle2.instance.paddleSpeed < 0.2 && times < 1f))
                return;
            float old = Paddle2.instance.paddleSpeed;
            Paddle2.instance.paddleSpeed *= times;
            text.GetComponent<UnityEngine.UI.Text>().text = old + "*" + times + "=" + Paddle2.instance.paddleSpeed + " paddle2";
        }
    }

}
