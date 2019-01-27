using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {
    
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
    public GameObject GOPl1text;
    public GameObject GOPl2text;
    public GameObject NGtext;
    public GameObject EXITtext;
    public GameObject NGbox;
    public GameObject EXITbox;
    private bool visibleEnd = false;
    
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
                bricks1[i][j] = chosenBrick(x, y);
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
                bricks2[i][j] = chosenBrick(x, y);
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

    GameObject chosenBrick(float x, float y)
    {
        GameObject brick;
        float rand = Random.Range(0, 100);

        if (rand < 70f) {
            brick = Instantiate(brickPrefab, new Vector3(x, y, 0), Quaternion.identity);
        } else if (rand < 73f) {
            brick = Instantiate(brickPrefab2, new Vector3(x, y, 0), Quaternion.identity);
        } else if (rand < 76f) {
            brick = Instantiate(brickPrefab2, new Vector3(x, y, 0), Quaternion.identity);
        } else if (rand < 79f) {
            brick = Instantiate(brickPrefab3, new Vector3(x, y, 0), Quaternion.identity);
        } else if (rand < 82f) {
            brick = Instantiate(brickPrefab3, new Vector3(x, y, 0), Quaternion.identity);
        } else if (rand < 85f) {
            brick = Instantiate(brickPrefab5, new Vector3(x, y, 0), Quaternion.identity);
        } else if (rand < 88f) {
            brick = Instantiate(brickPrefab6, new Vector3(x, y, 0), Quaternion.identity);
        } else if (rand < 90f) {
            brick = Instantiate(brickPrefab7, new Vector3(x, y, 0), Quaternion.identity);
        } else if (rand < 92f) {
            brick = Instantiate(brickPrefab8, new Vector3(x, y, 0), Quaternion.identity);
        } else if (rand < 94f) {
            brick = Instantiate(brickPrefab9, new Vector3(x, y, 0), Quaternion.identity);
        } else if (rand < 96f) {
            brick = Instantiate(brickPrefab10, new Vector3(x, y, 0), Quaternion.identity);
        } else if (rand < 97f) {
            brick = Instantiate(brickPrefab11, new Vector3(x, y, 0), Quaternion.identity);
        } else if (rand < 98f) {
            brick = Instantiate(brickPrefab12, new Vector3(x, y, 0), Quaternion.identity);
        } else {
            brick = Instantiate(brickPrefab13, new Vector3(x, y, 0), Quaternion.identity);
        }

        return brick;
    }

    void checkGO()
    {
        if (lives1x <= -1 || bricksAmount2 == 0)
        {
            if (bricksAmount2 == 0 && addedBricks2 != null)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (addedBricks2[i].activeInHierarchy) return;
                }
            }
            GOPl1.SetActive(true);
            GOPl1text.SetActive(true);
            NGtext.SetActive(true);
            EXITtext.SetActive(true);
            NGbox.SetActive(true);
            EXITbox.SetActive(true);
            visibleEnd = true;
        } else if (lives2x <= -1 || bricksAmount1 == 0)
        {
            if (bricksAmount1 == 0 && addedBricks1 != null)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (addedBricks1[i].activeInHierarchy) return;
                }
            }
            GOPl2.SetActive(true);
            GOPl2text.SetActive(true);
            NGtext.SetActive(true);
            EXITtext.SetActive(true);
            NGbox.SetActive(true);
            EXITbox.SetActive(true);
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
                Ball1.instance.transform.localScale = new Vector3(1, 1, 1);
                Ball1.instance.transform.position = new Vector3(Paddle1.instance.transform.position.x, Paddle1.instance.transform.position.y + 1, 0);
                Ball1.instance.ballInPlay = false;
                Ball1.instance.setKinematic(true);

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
                Ball2.instance.transform.position = new Vector3(Paddle2.instance.transform.position.x, Paddle2.instance.transform.position.y - 1, 0);
                Ball2.instance.transform.localScale = new Vector3(1, 1, 1);
                Ball2.instance.ballInPlay = false;
                Ball2.instance.setKinematic(true);

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
            //   bricks1[yy][xx].SetActive(false);
            bricks1[yy][xx].transform.position = new Vector3(bricks1[yy][xx].transform.position.x, bricks1[yy][xx].transform.position.y, 100);
            bricksAmount1--;
        } else
        {
            //   bricks2[yy*(-1)-2][xx].SetActive(false);
            int yynew = yy * (-1) - 2;
            bricks2[yynew][xx].transform.position = new Vector3(bricks2[yynew][xx].transform.position.x, bricks2[yynew][xx].transform.position.y, 100);
            bricksAmount2--;
        }
        checkGO();        
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (visibleEnd && Input.GetKey(KeyCode.Return))
        {
            visibleEnd = false;

            GOPl1.SetActive(false);
            GOPl2.SetActive(false);
            GOPl1text.SetActive(false);
            GOPl2text.SetActive(false);
            NGtext.SetActive(false);
            EXITtext.SetActive(false);
            NGbox.SetActive(false);
            EXITbox.SetActive(false);
            
            Paddle1.instance.transform.position = new Vector3(0, -8, 0);
            Paddle2.instance.transform.position = new Vector3(0, 31, 0);

            Paddle1.instance.transform.localScale = new Vector3(3, 1, 1);
            Paddle2.instance.transform.localScale = new Vector3(3, 1, 1);

            Paddle1.instance.paddleSpeed = 0.5f;
            Paddle2.instance.paddleSpeed = 0.5f;


            Ball1.instance.transform.localScale = new Vector3(1, 1,1);            
            Ball1.instance.transform.position = new Vector3(Paddle1.instance.transform.position.x, Paddle1.instance.transform.position.y + 1, 0);
            Ball1.instance.ballInPlay = false;
            Ball1.instance.setKinematic(true);

            Ball2.instance.transform.localScale = new Vector3(1,1,1);
            Ball2.instance.transform.position = new Vector3(Paddle2.instance.transform.position.x, Paddle2.instance.transform.position.y - 1, 0);
            Ball2.instance.ballInPlay = false;
            Ball2.instance.setKinematic(true);


            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Destroy(bricks1[i][j]);
                    Destroy(bricks2[i][j]);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                Destroy(life1Array[i]);
                Destroy(life2Array[i]);
            }

            for (int i = 0; i < 9; i++)
            {
                if (addedBricks1 != null)  addedBricks1[i].SetActive(false);
                if (addedBricks2 != null) addedBricks2[i].SetActive(false);
            }

            setupGame();
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
                    //             bricks2[i][j].SetActive(true);
                    bricks1[i][j].transform.position = new Vector3(bricks1[i][j].transform.position.x, bricks1[i][j].transform.position.y, 0);

                }
            }
            bricksAmount2 = 45;
            Ball1.instance.transform.position = new Vector3(Paddle1.instance.transform.position.x, Paddle1.instance.transform.position.y - 1, 0);
            Ball1.instance.ballInPlay = false;
            Ball1.instance.setKinematic(true);

        } else
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                //    bricks1[i][j].SetActive(true);
                    bricks1[i][j].transform.position = new Vector3(bricks2[i][j].transform.position.x, bricks2[i][j].transform.position.y, 0);
                }
            }
            bricksAmount1 = 45;
            Ball2.instance.transform.position = new Vector3(Paddle2.instance.transform.position.x, Paddle2.instance.transform.position.y + 1, 0);
            Ball2.instance.ballInPlay = false;
            Ball2.instance.setKinematic(true);
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
            
            Paddle1.instance.paddleSpeed *= times;
        } else
        {
            if ((Paddle2.instance.paddleSpeed > 4 && times > 1f)
                || (Paddle2.instance.paddleSpeed < 0.2 && times < 1f))
                return;

            Paddle2.instance.paddleSpeed *= times;
        }
    }

    public void enlargeBall(int id, float times)
    {
        if (id == 1)
        {
            if ((Ball1.instance.transform.localScale.x > 3 && times > 1f) 
                || (Ball1.instance.transform.localScale.x < 0.1f && times < 1f))
                return;
            Ball1.instance.changeSize(times);
        }
        else
        {
            if ((Ball2.instance.transform.localScale.x > 3 && times > 1f)
                || (Ball2.instance.transform.localScale.x < 0.1f && times < 1f))
                return;

            Ball2.instance.changeSize(times);
        }
    }

    public void enlargePaddle(int id, float times)
    {
        if (id == 1)
        {
            if ((Paddle1.instance.transform.localScale.x > 3 && times > 1f)
                || (Paddle1.instance.transform.localScale.x < 3f && times < 1f))
                return;
            Paddle1.instance.changeSize(times);
        }
        else
        {
            if ((Paddle2.instance.transform.localScale.x > 3 && times > 1f)
                || (Paddle2.instance.transform.localScale.x < 3f && times < 1f))
                return;

            Paddle2.instance.changeSize(times);
        }
    }

    public void shrinkPaddle(int id, float times)
    {
        if (id == 1)
        {
            if (Paddle1.instance.transform.localScale.x < 1.5f && times < 1f) return;

            Paddle1.instance.changeSize(times);
        }
        else
        {
            if (Paddle2.instance.transform.localScale.x < 1.5f && times < 1f) return;

            Paddle2.instance.changeSize(times);
        }
    }

    //     text.GetComponent<UnityEngine.UI.Text>().text = old + "*" + times + "=" + Paddle2.instance.paddleSpeed + " paddle2";

}
